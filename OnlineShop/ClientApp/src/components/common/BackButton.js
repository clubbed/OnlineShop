import React from "react";

const BackButton = ({ goBack }) => {
  return (
    <button className="btn btn-warning" onClick={goBack}>
      Go back
    </button>
  );
};

export default BackButton;
