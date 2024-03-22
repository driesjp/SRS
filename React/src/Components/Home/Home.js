import React from 'react';
import Menu from '../Menu/Menu';
import { StatisticsProvider } from '../../Context/StatisticsContext';
import '../../App.css';
import './Home.css';
import StatisticsData from './StatisticsData';

function Home() {
  return (
    <div className="Home">
      <Menu />
      <h1>Statistics</h1>
      <StatisticsProvider>
        <StatisticsData />
      </StatisticsProvider>
    </div>
  );
}

export default Home;