import React from "react";
import { Route, Switch } from "react-router";
import Layout from "./components/layouts/Layout";
import EmptyLayout from "./components/layouts/EmptyLayout";
import AdminLayout from "./components/layouts/AdminLayout";
import Home from "./components/Home";
import Counter from "./components/Counter";
import RegisterPage from "./components/RegisterPage";
import LoginPage from "./components/LoginPage";
import UserRoute from "./components/routes/UserRoute";
import GuestRoute from "./components/routes/GuestRoute";
import AdminRoute from "./components/routes/AdminRoute";
import NavMenu from "./components/NavMenu";
import ProductDetails from "./components/product/ProductDetails";
import CreateProductPage from "./components/admin/product/CreateProductPage";
import CategoryPage from "./components/CategoryPage";
import NotFound from "./components/common/NotFound";
import Dashboard from "./components/admin/Dashboard";

const App = ({ location }) => (
  <React.Fragment>
    {/* <NavMenu /> */}
    <Switch>
      <GuestRoute exact path="/" layout={EmptyLayout} component={Home} />
      <GuestRoute path="/login" layout={EmptyLayout} component={LoginPage} />
      <GuestRoute
        path="/register"
        layout={EmptyLayout}
        component={RegisterPage}
      />
      <UserRoute path="/counter" layout={Layout} component={Counter} />
      <Route path="/product/:id" layout={Layout} component={ProductDetails} />
      <Route path="/category/:id layout={Layout}" component={CategoryPage} />
      <AdminRoute
        exact
        path="/admin"
        layout={AdminLayout}
        component={Dashboard}
      />
      <AdminRoute
        exact
        path="/admin/product/create"
        layout={AdminLayout}
        component={CreateProductPage}
      />
      <Route path="*" layout={EmptyLayout} component={NotFound} />
    </Switch>
  </React.Fragment>
);

export default App;
