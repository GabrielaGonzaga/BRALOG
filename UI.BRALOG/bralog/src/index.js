import React from 'react';
import ReactDOM from 'react-dom';
import Login from './Pages/Login/login';
import Home from './Pages/Home/home';
import Produtos from './Pages/Produtos/produtos';
import SideBar from '../src/Components/Sidebar';
import {
  BrowserRouter,
  Routes,
  Route,
} from "react-router-dom";


const routing = (
  <BrowserRouter>
        <div>

        </div>
      <Routes>   
          <Route exact path="/" element={<Login/>}></Route>
          <Route exact path="/Home" element={<Home/>}></Route>
          <Route exact path="/Produtos" element={<Produtos/>}></Route>
      </Routes>
  </BrowserRouter>
);

ReactDOM.render(routing, document.getElementById('root'));


// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals

