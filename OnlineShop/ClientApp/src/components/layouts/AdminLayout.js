import React from "react";
import NavMenu from "../NavMenu";

const AdminLayout = ({ children }) => {
  return (
    <React.Fragment>
      <NavMenu />
      <div className="col-md-12">{children}</div>
    </React.Fragment>
  );
};

export default AdminLayout;
