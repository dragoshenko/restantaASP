
import logo from './logo.svg';
import React, { useEffect, useState } from 'react';
import axios, { AxiosResponse } from 'axios';
import './App.css';

const fetchData = async (apiUrl: string): Promise<any> => {
  try {
    const response = await axios.get(apiUrl);
    return response.data;
  } catch (error) {
    console.error('Error fetching data:', error);
    throw error;
  }
};

function App() {
//F12
useEffect(() => {
  axios.get('https://localhost:7228/api/Actor')
    .then((response: AxiosResponse<any>) =>{
      console.log(response.data);
    })
}, [])
useEffect(() => {
  axios.get('https://localhost:7228/api/Film')
    .then((response: AxiosResponse<any>) =>{
      console.log(response.data);
    })
}, [])

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          
          target="_blank"
          rel="noopener noreferrer"
        >
          Front-end
        </a>
      </header>
    </div>
  );
}

export default App;
