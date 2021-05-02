import React, { useState  } from 'react';
import { withRouter } from "react-router-dom";
import { Form,   } from "react-bootstrap/Form";
import { Button } from "react-bootstrap/Button";
import "./Login.css";

export const Login = () => {
    const [userId, setUserId] = useState("");
    const [password, setPassword] = useState("");

    function validateForm() {
        return userId.length > 0 && password.length > 0;
    }

    function handleSubmit(event) {
        event.preventDefault();
    }

    return (
        <div className="Login">
            <Form onSubmit={handleSubmit}>
                <Form.Group size="lg" controlId="email">
                    <Form.Label>User Id: </Form.Label>
                    <Form.Control
                        autoFocus
                        type="text"
                        value={userId}
                        onChange={(e) => setUserId(e.target.value)}
                    />
                </Form.Group>
                <Form.Group size="lg" controlId="password">
                    <Form.Label>Password</Form.Label>
                    <Form.Control
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </Form.Group>
                <Button block size="lg" type="submit" disabled={!validateForm()}>
                    Login
        </Button>
            </Form>
        </div>
    );
}

export default withRouter(Login);
