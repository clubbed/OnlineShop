import axios from "axios";
import jwtDecode from "jwt-decode";

const REGISTER_SUCCESS = "REGISTER_SUCCESS";
const REGISTER_FAILED = "REGISTER_FAILED";
const LOGIN_SUCCESS = "LOGIN_SUCCESS";
const LOGIN_FAILED = "LOGIN_FAILED";
const LOG_OUT = "LOG_OUT";
const REFRESH_AUTH = "REFRESH_AUTH";

export function refreshAuth(data) {
  return {
    type: REFRESH_AUTH,
    payload: data,
  };
}

export function loginSuccess(data) {
  return {
    type: LOGIN_SUCCESS,
    payload: data,
  };
}

function loginFailed(data) {
  return {
    type: LOGIN_FAILED,
    payload: data,
  };
}

export const login = (data) => (dispatch) => {
  console.log("called login");
  axios.post("/api/auth/login", data).then(
    (success) => {
      localStorage.token = success.data.token;
      dispatch(loginSuccess(success.data));
    },
    (err) => {
      dispatch(loginFailed(err.response.data));
    }
  );
};

function registerSuccess(data) {
  return {
    type: REGISTER_SUCCESS,
    payload: data,
  };
}

function registerFailed(data) {
  return {
    type: REGISTER_FAILED,
    payload: data,
  };
}

export const register = (data) => (dispatch) => {
  console.log("called register");
  axios.post("/api/auth/register", data).then(
    (success) => {
      console.log("success", success);
      localStorage.token = success.data.token;
      dispatch(registerSuccess(success.data));
    },
    (error) => {
      console.log("error", error);
      dispatch(registerFailed(error.response.data));
    }
  );
};

export const logOut = () => (dispatch) => {
  localStorage.removeItem("token");
  dispatch({
    type: LOG_OUT,
  });
};

const intialState = {
  email: "",
  token: "",
  isAuthenticated: false,
  error: [],
  roles: [],
};

export function reducer(state = intialState, action) {
  switch (action.type) {
    case REGISTER_SUCCESS:
      var user = jwtDecode(action.payload.token);
      return {
        ...state,
        email: action.payload.email,
        token: action.payload.token,
        isAuthenticated: true,
        roles: user.role,
      };
    case REGISTER_FAILED:
      return { ...state, error: action.payload };
    case LOGIN_SUCCESS:
      var user = jwtDecode(action.payload.token);
      return {
        ...state,
        email: action.payload.email,
        token: action.payload.token,
        isAuthenticated: true,
        roles: user.role,
      };
    case LOGIN_FAILED:
      return { ...state, error: action.payload };
    case REFRESH_AUTH:
      return {
        ...state,
        email: action.payload.email,
        token: action.payload.token,
        isAuthenticated: true,
        roles: action.payload.role,
      };
    case LOG_OUT:
      return {};
    default:
      return state;
  }
}
