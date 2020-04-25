import React from "react";

const Pagination = ({
  currentPage,
  totalPages,
  loadAllProducts,
  hasPrevious,
  hasNext,
}) => {
  let previous = hasPrevious ? "" : "disabled";
  let next = hasNext ? "" : "disabled";
  const elements = [];
  for (let page = 1; page <= totalPages; page++) {
    let active = currentPage == page ? "active" : "";
    elements.push(
      <li
        key={page}
        className={`page-item ${active}`}
        style={{ cursor: "pointer" }}
        onClick={() => {
          loadAllProducts(page, 10);
        }}
      >
        <a className="page-link">{page}</a>
      </li>
    );
  }

  return (
    <nav aria-label="Page navigation example" className="text-center">
      <ul className="pagination">
        <li className={`page-item ${previous}`}>
          <a className="page-link">Previous</a>
        </li>
        {elements}
        <li className={`page-item ${next}`}>
          <a className="page-link">Next</a>
        </li>
      </ul>
    </nav>
  );
};

export default Pagination;
