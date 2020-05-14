const ADD_TO_CART = "ADD_TO_CART";
const REMOVE_FROM_CART = "REMOVE_FROM_CART";
const EMPTY_CART = " EMPTY_CART";

export const addToCart = (data) => {
  return { type: ADD_TO_CART, payload: data };
};

export const removeFromCart = (id) => {
  return {
    type: REMOVE_FROM_CART,
    id,
  };
};

export const emptyItems = () => {
  return {
    type: EMPTY_CART,
  };
};

export const emptyCart = () => (dispatch) => {
  console.log("empty card");
  dispatch(emptyItems());
};

const initialState = {
  items: [],
  total: 0,
};

export const reducer = (state = initialState, action) => {
  switch (action.type) {
    case ADD_TO_CART:
      console.log("action payload", action.payload);
      var item = state.items.find((c) => c.id === action.payload.id);

      console.log("item on reducer", item);

      if (item) {
        item.qty += 1;
        return {
          ...state,
          total: state.total + item.price,
        };
      } else {
        action.payload.qty = 1;
        return {
          ...state,
          //   items: [...state, action.payload],
          items: state.items.concat(action.payload),
          total: state.total + action.payload.price,
        };
      }
    case REMOVE_FROM_CART:
      var itemRemoved = state.items.find((c) => c.id === action.id);
      var filteredItems = state.items.filter((c) => c.id !== action.id);
      return {
        ...state,
        items: filteredItems,
        total: state.total - itemRemoved.price * itemRemoved.qty,
      };
    case EMPTY_CART:
      return { items: [], total: 0 };
    default:
      return state;
  }
};
