
import React from 'react';
import { Routes, Route, Link } from 'react-router-dom';
import SignUp from './pages/SignUp';
import Login from './pages/Login';
import BlogList from './pages/BlogList';

function App() {
  return (
    <div>
      <Routes>
        <Route path="/" element={<BlogList />} />
        <Route path="/signup" element={<SignUp />} />
        <Route path="/login" element={<Login />} />
      </Routes>
    </div>
  );
}

export default App;
