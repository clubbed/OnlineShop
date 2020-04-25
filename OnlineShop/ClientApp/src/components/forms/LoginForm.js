import React, { useState } from "react";
import { connect } from "react-redux";
import validator from "validator";
import { isEmpty } from "lodash";
import ValidationError from "../common/ValidationError";

const LoginForm = (props) => {
  const [user, setUser] = useState({
    email: "",
    password: "",
    loading: false,
    errors: {},
  });

  const onchange = (e) => {
    setUser({
      ...user,
      [e.target.name]: e.target.value,
    });
  };

  const submit = (e) => {
    e.preventDefault();

    // const errors = validate(user);
    // setUser({ ...user, errors: errors });

    // if (!isEmpty(validate())) {
    //   setUser({ ...user, errors: validate() });
    // }
    const errors = validate(user);

    isEmpty(errors)
      ? props.onSubmit(user)
      : setUser({ ...user, errors: errors });
  };

  const validate = (user) => {
    var errors = {};
    if (!validator.isEmail(user.email)) errors.email = "It should be an email";
    if (validator.isEmpty(user.email)) errors.email = "Email can't be empty";
    if (validator.isEmpty(user.password))
      errors.password = "Password can't be empty";

    return errors;
  };

  return (
    <form
      onSubmit={(e) => {
        submit(e);
      }}
    >
      {props.serverError && (
        <div className="text-center text-danger">{props.serverError}</div>
      )}
      <div>
        <label htmlFor="email">Email:</label>
        <input
          type="email"
          name="email"
          value={user.email}
          onChange={onchange}
          className="form-control"
        />
        {user.errors.email && <ValidationError text={user.errors.email} />}
      </div>
      <div>
        <label htmlFor="password">Password:</label>
        <input
          type="password"
          name="password"
          value={user.password}
          onChange={onchange}
          className="form-control"
        />
        {user.errors.password && (
          <ValidationError text={user.errors.password} />
        )}
      </div>
      <div className="text-center" style={{ marginTop: "10px" }}>
        <button type="submit" className="btn btn-success">
          Login
        </button>
      </div>
    </form>
  );
};

function mapStateToProps(state) {
  return {
    serverError: state.auth.error,
  };
}

export default connect(mapStateToProps)(LoginForm);
