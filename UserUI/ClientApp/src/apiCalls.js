import React from "react";
import { render } from "react-dom";


export const getSessionValue = function (key) {
    return JSON.parse(window.localStorage.getItem(key));
};


export const apiCall = (
    endpoint,
    method = "GET",
    data = {},
    headers = {},
    cache = "no-cache",
    mode = "cors",
    options = {}
) => {
    let baseURL, token;

    baseURL = 'http://localhost/userapi';
    token = getSessionValue("token");

    const fullUrl = baseURL + endpoint;
    let _headers = new Headers({
        Accept: "application/json",
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`
    });

    Object.keys(headers).forEach((key) => {
        _headers.append(key, headers[key]);
    });
    let request = {};

    if (method !== "GET") {
        request = new Request(fullUrl, {
            method: method,
            mode: mode,
            cache: cache,
            headers: _headers,
            // credentials: "include",
            body: JSON.stringify(data),
        });
    } else {
        request = new Request(fullUrl, {
            method: method,
            mode: mode,
            cache: cache,
            headers: _headers,
            // credentials: "include"
        });
    }

    return fetch(request, options)
        .then((res) => {
            return res.json();
        })
        .catch((error) => {

            console.log("API call Error : ", error);
            if (error.status === 403) {
                render(<div>You don't have access to this contact!!!</div>);
            }
            throw new Error(error.message || " Network request failed");
        });
}