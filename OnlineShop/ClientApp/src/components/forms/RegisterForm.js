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
      <label htmlFor="email">Email:</label>
      <input
        type="email"
        name="email"
        className="form-control"
        value={user.email}
        onChange={onchange}
      />
      <label htmlFor="password">Password:</label>
      <input
        type="password"
        name="password"
        className="form-control"
        value={user.password}
        onChange={onchange}
      />
      <label htmlFor="confirmPassword">Confirm Password:</label>
      <input
        type="password"
        name="confirmPassword"
        className="form-control"
        value={user.confirmPassword}
        onChange={onchange}
      />
      <div className="text-center mt-4">
        <button type="submit" className="btn btn-primary">
          Register
        </button>
      </div>
    </form>
  );
}

export default RegisterForm;
