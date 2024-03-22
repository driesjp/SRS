import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';  // Import components from React Router DOM for declarative routing.
// Import component modules for different pages.
import Start from './Components/Start/Start';
import Home from './Components/Home/Home';
import Learn from './Components/Learn/Learn';
import Review from './Components/Review/Review';
import './App.css';

// Define the main App component.
function App() {
  return (
    // Wrap the entire application within the Router component to enable routing capabilities.
    <Router>
      <div className="App">
        <Routes>
          <Route path="/" element={<Start />} />
          <Route path="/home" element={<Home />} />
          <Route path="/learn" element={<Learn />} />
          <Route path="/review" element={<Review />} />
        </Routes>
      </div>
    </Router>
  );
}

// Export the App component to be used in other parts of the application
export default App;