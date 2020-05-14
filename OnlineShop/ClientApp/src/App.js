import React from "react";
import { Route, Switch } from "react-router";
import Layout from "./components/layouts/Layout";
import EmptyLayout from "./components/layouts/EmptyLayout";
import AdminLayout from "./components/layouts/AdminLayout";
import Home from "./components/Home";
import RegisterPage from "./components/account/RegisterPage";
import LoginPage from "./components/account/LoginPage";
import UserRoute from "./components/routes/UserRoute";
import GuestRoute from "./components/routes/GuestRoute";
import AdminRoute from "./components/routes/AdminRoute";
import ProductDetails from "./components/product/ProductDetails";
import CreateProductPage from "./components/admin/product/CreateProductPage";
import CategoryPage from "./components/category/CategoryPage";
import NotFound from "./components/common/NotFound";
import Dashboard from "./components/admin/Dashboard";
import CartPage from "./components/cart/CartPage";
import CheckOutPage from "./components/cart/CheckOutPage";
import OrdersPage from "./components/orders/OrdersPage";
import ListProductPage from "./components/admin/product/ListProductPage";
import DeleteProductPage from "./components/admin/product/DeleteProductPage";
import EditProductPage from "./components/admin/product/EditProductPage";
import VendorPage from "./components/admin/vendor/VendorPage";
import MeasureUnitPage from "./components/admin/measureUnit/MeasureUnitPage";
import ShippingTypePage from "./components/admin/shippingType/ShippingTypePage";
import OrderListPage from "./components/admin/order/OrderListPage";
import OrderDetailsPage from "./components/admin/order/OrderDetailsPage";

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
        exact
        path="/admin/products"
        layout={AdminLayout}
        component={ListProductPage}
      />
      <AdminRoute
        path="/admin/products/create"
        layout={AdminLayout}
        component={CreateProductPage}
      />
      <AdminRoute
        path="/admin/products/edit/:id"
        layout={AdminLayout}
        component={EditProductPage}
      />
      <AdminRoute
        path="/admin/products/delete/:id"
        layout={AdminLayout}
        component={DeleteProductPage}
      />
      <AdminRoute
        path="/admin/vendors"
        layout={AdminLayout}
        component={VendorPage}
      />
      <AdminRoute
        path="/admin/measureunits"
        layout={AdminLayout}
        component={MeasureUnitPage}
      />
      <AdminRoute
        path="/admin/shippingtypes"
        layout={AdminLayout}
        component={ShippingTypePage}
      />
      <AdminRoute
        path="/admin/orders"
        layout={AdminLayout}
        component={OrderListPage}
      />
      <AdminRoute
        path="/admin/order/:id"
        layout={AdminLayout}
        component={OrderDetailsPage}
      />
      <Route layout={EmptyLayout} component={NotFound} />
    </Switch>
  </React.Fragment>
);

export default App;
