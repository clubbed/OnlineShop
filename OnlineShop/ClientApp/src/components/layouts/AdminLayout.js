import React from "react";
import NavMenu from "../NavMenu";
import AdminNavBar from "../admin/AdminNavBar";

const AdminLayout = ({ children }) => {
  return (
    <React.Fragment>
      {/* <NavMenu /> */}
      <div className="container" style={{paddingTop:"40px"}}>
      <AdminNavBar />
      <div className="col-md-12">{children}</div>
      </div>
    </React.Fragment>
  );
};

export default AdminLayout;
