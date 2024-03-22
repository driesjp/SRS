import React from 'react';
import Menu from '../Menu/Menu'; 
import ListNewVocab from './ListNewVocab'; 
import { LearnProvider } from '../../Context/LearnContext';
import '../../App.css';
import './Learn.css';

function Learn() {
  return (
    <div className="Learn">
      <Menu />
      <h1>Learn</h1>
      <LearnProvider>
        <ListNewVocab />
      </LearnProvider>
    </div>
  );
}

export default Learn;