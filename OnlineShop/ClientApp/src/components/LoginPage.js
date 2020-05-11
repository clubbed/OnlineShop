import React, { Component } from "react";
import { connect } from "react-redux";
import LoginForm from "./forms/LoginForm";
import { login } from "../store/Auth";

class LoginPage extends Component {
  onsubmit = (data) => {
    this.props.login(data);
    this.props.history.push("/");
  };

  componentDidMount() {
    if (this.props.isAuthenticated) {
      this.props.history.push("/");
    }
  }

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

function mapStateToProps(state) {
  return {
    isAuthenticated: state.auth.isAuthenticated,
  };
}

export default connect(mapStateToProps, { login })(LoginPage);
