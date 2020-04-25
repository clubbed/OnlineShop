import React from "react";
import { connect } from "react-redux";
import { Route, Redirect } from "react-router-dom";

const UserRoute = ({
  isAuthenticated,
  layout: Layout,
  component: Component,
  ...rest
}) => (
  <Route
    {...rest}
    render={(props) =>
      isAuthenticated ? (
        <Layout>
          <Component {...props} />
        </Layout>
      ) : (
        <Redirect to={{ pathname: "/login" }} />
      )
    }
  />
);

function mapStateToProps(state) {
  return {
    isAuthenticated: state.auth.isAuthenticated,
  };
}

export default connect(mapStateToProps)(UserRoute);
