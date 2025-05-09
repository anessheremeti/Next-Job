import React, { useState } from 'react';
import serviceLogin from "../../assets/service-login.png";
import leftSign from "../../assets/left-sign.png";
import vertical from "../../assets/vertical.png";
import logo from "../../assets/Logo 1.png";
import axios from 'axios';

function SignIn() {
  const [formData, setFormData] = useState({
    email: '',
    password: ''
  });

  const [errors, setErrors] = useState({
    email: '',
    password: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value
    });

    if (errors[name]) {
      setErrors({
        ...errors,
        [name]: ''
      });
    }
  };

  const validateForm = () => {
    let valid = true;
    const newErrors = { email: '', password: '' };

    if (!formData.email) {
      newErrors.email = 'Email is required';
      valid = false;
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(formData.email)) {
      newErrors.email = 'Invalid email format';
      valid = false;
    }

    if (!formData.password) {
      newErrors.password = 'Password is required';
      valid = false;
    } else if (formData.password.length < 8) {
      newErrors.password = 'Password must be at least 8 characters';
      valid = false;
    }

    setErrors(newErrors);
    return valid;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!validateForm()) return;

    try {
      const response = await axios.post('http://localhost:5123/login', {
        email: formData.email,
        password: formData.password
      }, {
        headers: {
          'Content-Type': 'application/json'
        }
      });

      if (response.status === 200) {
        alert('Login successful!');
        console.log('Logged in:', response.data);

        // Ruaje tokenin nëse përdoret (opsionale)
        // localStorage.setItem("token", response.data.token);

        setFormData({ email: '', password: '' });
      }
    } catch (error) {
      if (error.response?.status === 400 || error.response?.status === 401) {
        alert(`Login failed: ${error.response.data}`);
      } else {
        alert('Login failed. Please try again later.');
      }
      console.error('Login error:', error);
    }
  };

  return (
    <div className='flex flex-col items-center lg:flex-row justify-center mx-10 my-40 gap-16'>
      <img src={serviceLogin} alt="service-login" className='hidden lg:flex'/>
      <div className='flex flex-col'>
        <form onSubmit={handleSubmit} className='flex flex-col gap-3'>
          <div className='flex items-center gap-2 cursor-pointer'>
            <img src={leftSign} alt="left-sign" />
            <a href='#' className='text-[#00000080] font-poppins hover:underline'>Back to Home</a>
          </div>
          <div className='flex items-center justify-center gap-5 flex-col md:flex-row'>
            <h1 className='text-6xl text-[#216F4C] font-poppins font-medium flex flex-row'>Sign In</h1>
            <img src={vertical} alt="vertical" className='hidden xl:flex' />
            <img src={logo} alt="logo" />
          </div>

          <label htmlFor="email" className='font-poppins text-[#00000080] text-lg'>Email</label>
          <input
            type="email"
            name="email"
            placeholder='Enter Email'
            className={`border rounded-full p-3 border-[#216F4C] ${errors.email ? 'border-red-500' : ''}`}
            value={formData.email}
            onChange={handleChange}
          />
          {errors.email && <p className="text-red-500 text-sm -mt-2">{errors.email}</p>}

          <label htmlFor="password" className='font-poppins text-[#00000080] text-lg'>Password</label>
          <input
            type="password"
            name="password"
            placeholder='Enter Password'
            className={`border rounded-full p-3 border-[#216F4C] ${errors.password ? 'border-red-500' : ''}`}
            value={formData.password}
            onChange={handleChange}
          />
          {errors.password && <p className="text-red-500 text-sm -mt-2">{errors.password}</p>}

          <button
            type="submit"
            className='bg-[#216F4C] self-center w-[70%] p-2 text-white font-poppins rounded-full mt-5 hover:bg-[#2a9464]'
          >
            Sign In
          </button>

          <div className='flex items-center justify-center gap-2 text-[#00000080]'>
            <p>Don't have an account?</p>
            <a className='text-[#216F4C] font-semibold font-poppins hover:underline' href="/choose">Register</a>
          </div>
        </form>
      </div>
    </div>
  );
}

export default SignIn;
