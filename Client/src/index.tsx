import * as React from 'react';
import { render } from 'react-dom';
import { BrowserRouter } from 'react-router-dom';

import App from './App';
import './styles/app.css';

const app = (
  <BrowserRouter basename='#'>
    <App />
  </BrowserRouter>
);

render(
  app,
  document.getElementById('root')
);
