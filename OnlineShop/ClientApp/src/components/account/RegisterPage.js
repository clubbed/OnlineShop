import React, { Component } from "react";
import RegisterForm from "../forms/RegisterForm";
import { connect } from "react-redux";
import { register } from "../../store/Auth";

class RegisterPage extends Component {
  onSubmit = (data) => {
    this.props.register(data);
    this.props.history.push("/");
  };

  componentDidMount() {
    if (this.props.isAuthenticated) {
      this.props.history.push("/");
    }
  }

  render() {
    return (
      <div className="col-md-6 col-md-offset-3">
        <h2 className="text-center">Register</h2>
        <RegisterForm onSubmit={this.onSubmit}></RegisterForm>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    isAuthenticated: state.auth.isAuthenticated,
  };
}
export default connect(mapStateToProps, { register })(RegisterPage);
