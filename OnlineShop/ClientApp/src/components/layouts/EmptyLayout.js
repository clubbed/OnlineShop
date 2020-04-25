import React from "react";
import NavMenu from "../NavMenu";

const EmptyLayout = ({ children }) => {
  return (
    <React.Fragment>
      <NavMenu />
      <div className="col-md-12">{children}</div>
    </React.Fragment>
  );
};

export default EmptyLayout;
