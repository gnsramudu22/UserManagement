import React, { useEffect, useState } from "react";
import { apiCall } from "../../apicalls.js";
import { AgGridColumn, AgGridReact } from 'ag-grid-react';
import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-alpine.css';

function Home(props) {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState([]);

    const fetchData = async () => {
        const resp = await apiCall('/users', 'GET')
        setUsers(resp.List);
        setLoading(false);
    };

    useEffect(() => {
        fetchData();
    }, []);

    const handleSubmitClick = () => {
        console.log(users)

    }

    const renderUsersTable = (users) => {
        return (
            <div>
                
                <div className="ag-theme-alpine grid-records" >
                    <AgGridReact defaultColDef={{
                        flex: 1,
                        minWidth: 130,
                        editable: true,
                        resizable: true,
                    }}
                        rowData={users}>
                        <AgGridColumn field="UserId" headerName="User Id"></AgGridColumn>
                        <AgGridColumn field="FirstName" headerName="First Name"></AgGridColumn>
                        <AgGridColumn field="LastName" headerName="Last Name"></AgGridColumn>
                        <AgGridColumn field="Email" headerName="Email"></AgGridColumn>
                        <AgGridColumn field="IsActive" headerName="Active"></AgGridColumn>
                    </AgGridReact>
                </div>
                <button
                    type="submit"
                    className="btn btn-primary" disabled={users ? false : true}
                    onClick={handleSubmitClick}
                >Submit</button>
            </div>
        );
    }

    return(
        <div>
            <h1>Users</h1>
            {loading
                ? <p><em>Loading...</em></p>
                : renderUsersTable(users)}
        </div>
    )
}

export default Home;