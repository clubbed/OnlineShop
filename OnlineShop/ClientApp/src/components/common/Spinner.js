import React from "react";

const Spinner = () => {
  return (
    <div className="text-center">
      <div
        className="spinner-border"
        style={{ height: "100px", width: "100px", top: 50, left: 50 }}
        role="status"
      >
        <span className="sr-only">Loading...</span>
      </div>
    </div>
  );
};

export default Spinner;
