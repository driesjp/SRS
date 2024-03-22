// src/Components/Start/Start.js
import React from 'react';
import logo from '../../Assets/logo.png';
import overlayImage from '../../Assets/arm.png'; // Adjust the path as needed
import { Link } from 'react-router-dom';
import '../../App.css';
import './Start.css';

function Start() {
  return (
    <div className="Start">
      <header className="Start-header">
        <div className="Logo-wrapper">
          <img src={logo} className="App-logo" alt="logo" />
          <img src={overlayImage} className="Overlay-image" alt="Overlay" />
        </div>
        <p>
          Facts about ducks! <br />(Spaced Repetition System demo)</p>
          <p> Click here to get started on your learning journey:</p>
          
        <p>
        &gt; <Link to="/home">
            I love ducks
          </Link> &lt;
        </p>
      </header>
    </div>
  );
}

export default Start;