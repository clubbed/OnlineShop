import React from "react";
import NavMenu from "../NavMenu";
import CategoryList from "../CategoryList";

const Layout = ({ children }) => {
  return (
    <React.Fragment>
      <NavMenu />
      <div className="col-md-3">
        <CategoryList />
      </div>
      <div className="col-md-9">{children}</div>
    </React.Fragment>
  );
};

export default Layout;
