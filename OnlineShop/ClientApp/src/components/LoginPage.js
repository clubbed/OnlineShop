import React, { Component } from "react";
import { connect } from "react-redux";
import LoginForm from "./forms/LoginForm";
import { login } from "../store/Auth";

class LoginPage extends Component {
  onsubmit = (data) => {
    this.props.login(data);
  };

  render() {
    return (
      <div>
        <h2 className="text-center">Login</h2>
        <div className="col-md-6 col-md-offset-3">
          <LoginForm onSubmit={this.onsubmit}></LoginForm>
        </div>
      </div>
    );
  }
}

export default connect(null, { login })(LoginPage);
