import "bootstrap/dist/css/bootstrap.css";
import "bootstrap/dist/css/bootstrap-theme.css";
import "./index.css";
import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { ConnectedRouter } from "react-router-redux";
import { createBrowserHistory } from "history";
import configureStore from "./store/configureStore";
import App from "./App";
import registerServiceWorker from "./registerServiceWorker";
// import { Route } from "react-router-dom";
import jwtDecode from "jwt-decode";
import { loginSuccess, refreshAuth } from "./store/Auth";

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const history = createBrowserHistory({ basename: baseUrl });

// Get the application-wide store instance, prepopulating with state from the server where available.
const initialState = window.initialReduxState;
const store = configureStore(history, initialState);

if (localStorage.token) {
  const auth = jwtDecode(localStorage.token);

  const refresh = {
    email: auth.unique_name,
    token: localStorage.token,
    isAuthenticated: true,
    role: auth.role,
  };
  store.dispatch(refreshAuth(refresh));
}

const rootElement = document.getElementById("root");

ReactDOM.render(
  <Provider store={store}>
    <ConnectedRouter history={history}>
      <App />
      {/* <Route component={App} /> */}
    </ConnectedRouter>
  </Provider>,
  rootElement
);

registerServiceWorker();
