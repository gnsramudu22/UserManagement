import React, { useState } from 'react';
import { apiCall } from "../apiCalls";
function RegistrationForm(props) {

    const [state, setState] = useState({
        userId: "",
        password: "",
        firstName: "",
        lastName: "",
        email: ""
    });

    const handleChange = (e) => {
        const { id, value } = e.target
        setState(prevState => ({
            ...prevState,
            [id]: value
        }))
    }
    const redirectToHome = () => {
        props.updateTitle('Home')
        props.history.push('/home');
    }
    const redirectToLogin = () => {
        props.updateTitle('Login')
        props.history.push('/login');
    }

    const handleSubmitClick = async (e) => {
        e.preventDefault();
        if (state.userId != '' && state.password != '') {
            props.showError('UserId & Password should not be empty');
        } else {
            let payload = {
                UserId: state.userId,
                Password: state.password,
                FirstName: state.firstName,
                LastName: state.lastName,
                Email: state.email
            }
            const resp = await apiCall('/user/save', 'POST', payload)
            if (resp.Data) {
                setState(prevState => ({
                    ...prevState,
                    'successMessage': 'Registration successful. Redirecting to home page..'
                }))
                redirectToHome();
                props.showError(null)
            } else {
                props.showError("Please enter valid username and password");
            }
        }


    }

    return (
        <div className="card col-12 col-lg-4 login-card mt-2 hv-center">
            <form>
                <div className="form-group text-left">
                    <label htmlFor="exampleInputEmail1">User Id</label>
                    <input type="text"
                        className="form-control"
                        id="userId"
                        aria-describedby="userIdHelp"
                        placeholder="Enter UserId"
                        value={state.userId}
                        onChange={handleChange}
                    />
                    <small id="userIdHelp" className="form-text text-muted">UserId should be alpha numaric and unique.</small>
                </div>
                <div className="form-group text-left">
                    <label htmlFor="exampleInputPassword1">Password</label>
                    <input type="password"
                        className="form-control"
                        id="password"
                        placeholder="Password"
                        value={state.password}
                        onChange={handleChange} 
                    />
                </div>
                <div className="form-group text-left">
                    <label htmlFor="exampleInputFirstName1">First Name</label>
                    <input type="text"
                        className="form-control"
                        id="firstName"
                        placeholder="First Name"
                        value={state.firstName}
                        onChange={handleChange} 
                    />
                </div>
                <div className="form-group text-left">
                    <label htmlFor="exampleInputLastName1">Last Name</label>
                    <input type="text"
                        className="form-control"
                        id="lastName"
                        placeholder="Last Name"
                        value={state.lastName}
                        onChange={handleChange} 
                    />
                </div>
                <div className="form-group text-left">
                    <label htmlFor="exampleInputEmail1">Email</label>
                    <input type="email"
                        className="form-control"
                        id="email"
                        placeholder="Email"
                        value={state.email}
                        onChange={handleChange} 
                    />
                </div>
                <button
                    type="submit"
                    className="btn btn-primary"
                    onClick={handleSubmitClick}
                >
                    Register
                </button>
            </form>
            <div className="alert alert-success mt-2" style={{ display: state.successMessage ? 'block' : 'none' }} role="alert">
                {state.successMessage}
            </div>
            <div className="mt-2">
                <span>Already have an account? </span>
                <span className="loginText" onClick={() => redirectToLogin()}>Login here</span>
            </div>
        </div>
    )
}
export default RegistrationForm;