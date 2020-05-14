import React, { useState, useEffect } from "react";
import * as service from "../../../services/productService";
const MeasureUnitPage = () => {
  const [measureUnits, setMeasureUnits] = useState([]);

  useEffect(() => {
    service.getMeasureUnits().then((response) => {
      console.log("response", response);
      setMeasureUnits(response.data);
    });
  }, []);

  const showMeasureUnits =
    measureUnits.length > 0
      ? measureUnits.map((m) => (
          <tr key={m.id}>
            <td>{m.id}</td>
            <td>{m.name}</td>
          </tr>
        ))
      : null;

  return (
    <div>
      <table className="table">
        <thead className="bg-warning">
          <tr>
            <th>Id</th>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>{showMeasureUnits}</tbody>
      </table>
    </div>
  );
};

export default MeasureUnitPage;
