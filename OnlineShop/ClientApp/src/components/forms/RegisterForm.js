import React, { useState } from "react";

function RegisterForm(props) {
  const [user, setUser] = useState({
    email: "",
    password: "",
    confirmPassword: "",
  });

  const onchange = (e) => {
    setUser({
      ...user,
      [e.target.name]: e.target.value,
    });
  };

  return (
    <form
      onSubmit={(e) => {
        e.preventDefault();
        props.onSubmit(user);
      }}
    >
      <input
        type="email"
        name="email"
        className="form-control"
        value={user.email}
        onChange={onchange}
      />
      <input
        type="password"
        name="password"
        className="form-control"
        value={user.password}
        onChange={onchange}
      />
      <input
        type="password"
        name="confirmPassword"
        className="form-control"
        value={user.confirmPassword}
        onChange={onchange}
      />
      <button type="submit" className="btn btn-primary">
        Register
      </button>
    </form>
  );
}

export default RegisterForm;
