import React from 'react';
import { Link } from 'react-router-dom'; // Assuming you're using React Router for navigation

function Menu() {
  return (
    <ul className="Menu">
      <li><Link to="/">Start</Link></li>
      <li>&#47;</li>
      <li><Link to="/home">Home</Link></li>
      <li><Link to="/learn">Learn</Link></li>
      <li><Link to="/review">Review</Link></li>
      {/* Add more menu items as needed */}
    </ul>
  );
}

export default Menu;