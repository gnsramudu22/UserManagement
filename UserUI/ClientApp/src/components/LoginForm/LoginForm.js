
import React, {useState} from 'react';
import './LoginForm.css';
//import {API_BASE_URL} from '../../constants/apiContants';
import { withRouter } from "react-router-dom";
import { apiCall } from "../../apiCalls";

function LoginForm(props) {
    const [state , setState] = useState({
        userId : "",
        password : "",
        successMessage: null
    })
    const handleChange = (e) => {
        const {id , value} = e.target   
        setState(prevState => ({
            ...prevState,
            [id] : value
        }))
    }

    const handleSubmitClick = async (e) => {
        e.preventDefault();
        const payload={
            "UserId":state.email,
            "Password":state.password,
        }
        const resp = await apiCall('/login/Authenticate', 'POST', payload)
        console.log(resp);
        if (resp.Data) {
            setState(prevState => ({
                ...prevState,
                'successMessage': 'Login successful. Redirecting to home page..'
            }))
            redirectToHome();
            props.showError(null)
        } else {
            props.showError("Invalid login credentials");
        }
       
    }
    const redirectToHome = () => {
        props.updateTitle('Home')
        props.history.push('/home');
    }
    const redirectToRegister = () => {
        props.history.push('/register'); 
        props.updateTitle('Register');
    }
    return(
        <div className="card col-12 col-lg-4 login-card mt-2 hv-center">
            <form>
                <div className="form-group text-left">
                <label htmlFor="exampleInputEmail1">User ID</label>
                <input type="text" 
                       className="form-control" 
                       id="userId" 
                       aria-describedby="userIdHelp" 
                       placeholder="Enter UserId" 
                       value={state.userId}
                       onChange={handleChange}
                />
                    <small id="userIdHelp" className="form-text text-muted">We'll never share your userid with anyone else.</small>
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
                <div className="form-check">
                </div>
                <button 
                    type="submit" 
                    className="btn btn-primary"
                    onClick={handleSubmitClick}
                >Submit</button>
            </form>
            <div className="alert alert-success mt-2" style={{display: state.successMessage ? 'block' : 'none' }} role="alert">
                {state.successMessage}
            </div>
            <div className="registerMessage">
                <span>Dont have an account? </span>
                <span className="loginText" onClick={() => redirectToRegister()}>Register</span> 
            </div>
        </div>
    )
}

export default withRouter(LoginForm);