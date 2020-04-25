import React, { Component } from "react";
import SideBar from "./SideBar";
import AdminNavBar from "./AdminNavBar";

class Dashboard extends Component {
  render() {
    return (
      <div className="col-md-12">
        <h2 className="text-center">Welcome to Dashboard</h2>
        <div className="row">
          <div className="col-md-8 col-md-offset-2">
            <AdminNavBar />
          </div>
        </div>
        <div className="row"></div>
      </div>
    );
  }
}

export default Dashboard;
