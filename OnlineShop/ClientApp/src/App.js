import React from "react";
import { Route, Switch } from "react-router";
import Layout from "./components/layouts/Layout";
import EmptyLayout from "./components/layouts/EmptyLayout";
import AdminLayout from "./components/layouts/AdminLayout";
import Home from "./components/Home";
import RegisterPage from "./components/RegisterPage";
import LoginPage from "./components/LoginPage";
import UserRoute from "./components/routes/UserRoute";
import GuestRoute from "./components/routes/GuestRoute";
import AdminRoute from "./components/routes/AdminRoute";
import ProductDetails from "./components/product/ProductDetails";
import CreateProductPage from "./components/admin/product/CreateProductPage";
import CategoryPage from "./components/CategoryPage";
import NotFound from "./components/common/NotFound";
import Dashboard from "./components/admin/Dashboard";
import CartPage from "./components/CartPage";
import CheckOutPage from "./components/CheckOutPage";
import OrdersPage from "./components/orders/OrdersPage";

const App = ({ location }) => (
  <React.Fragment>
    <Switch>
      <GuestRoute exact path="/" layout={EmptyLayout} component={Home} />
      <GuestRoute path="/login" layout={EmptyLayout} component={LoginPage} />
      <GuestRoute
        path="/register"
        layout={EmptyLayout}
        component={RegisterPage}
      />
      <GuestRoute
        path="/product/:id"
        layout={Layout}
        component={ProductDetails}
      />
      <GuestRoute
        path="/category/:id"
        layout={Layout}
        component={CategoryPage}
      />
      <UserRoute path="/cart" layout={EmptyLayout} component={CartPage} />
      <UserRoute path="/orders" layout={EmptyLayout} component={OrdersPage} />
      <UserRoute
        path="/checkout"
        layout={EmptyLayout}
        component={CheckOutPage}
      />
      <AdminRoute
        exact
        path="/admin"
        layout={AdminLayout}
        component={Dashboard}
      />
      <AdminRoute
        path="/admin/product/create"
        layout={AdminLayout}
        component={CreateProductPage}
      />
      <Route layout={EmptyLayout} component={NotFound} />
    </Switch>
  </React.Fragment>
);

export default App;
