import React from "react";
import NavMenu from "../NavMenu";
import CategoryList from "../category/CategoryList";

const Layout = ({ children }) => {
  return (
    <React.Fragment>
      <NavMenu />
      <div className="container" style={{ paddingTop: "40px" }}>
        <div className="col-md-3">
          <CategoryList />
        </div>
        <div className="col-md-9">{children}</div>
      </div>
    </React.Fragment>
  );
};

export default Layout;
