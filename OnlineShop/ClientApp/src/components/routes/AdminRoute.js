import React from "react";
import { Route, Redirect } from "react-router-dom";
import { connect } from "react-redux";

const AdminRoute = ({
  roles,
  layout: Layout,
  component: Component,
  ...rest
}) => (
  <Route
    {...rest}
    render={(props) =>
      roles !== undefined && roles.includes("Admin") ? (
        <Layout>
          <Component {...props} />
        </Layout>
      ) : (
        <Redirect to={{ pathname: "/" }} />
      )
    }
  />
);

function mapStateToProps(state) {
  return {
    roles: state.auth.roles,
  };
}

export default connect(mapStateToProps)(AdminRoute);
