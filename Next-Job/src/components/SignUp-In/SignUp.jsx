import React, { useState } from 'react';
import leftSign from "../../assets/left-sign.png";
import vertical from "../../assets/vertical.png";
import logo from "../../assets/Logo 1.png";
import serviceGroup from "../../assets/service-group.png";
import axios from 'axios';

function SignUp() {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    password: '',
    confirmPassword: ''
  });

  const [errors, setErrors] = useState({
    name: '',
    email: '',
    password: '',
    confirmPassword: ''
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
    const newErrors = { ...errors };

    if (!formData.name.trim()) {
      newErrors.name = 'Name is required';
      valid = false;
    }

    if (!formData.email) {
      newErrors.email = 'Email is required';
      valid = false;
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(formData.email)) {
      newErrors.email = 'Email is invalid';
      valid = false;
    }

    if (!formData.password) {
      newErrors.password = 'Password is required';
      valid = false;
    } else if (formData.password.length < 8) {
      newErrors.password = 'Password must be at least 8 characters';
      valid = false;
    }

    if (!formData.confirmPassword) {
      newErrors.confirmPassword = 'Please confirm your password';
      valid = false;
    } else if (formData.password !== formData.confirmPassword) {
      newErrors.confirmPassword = 'Passwords do not match';
      valid = false;
    }

    setErrors(newErrors);
    return valid;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
  
    if (validateForm()) {
      try {
        const response = await axios.post('http://localhost:5123/signup', {
          fullName: formData.name,
          companyName: "",               
          email: formData.email,
          password: formData.password,
          image: "",                     
          userType: "Freelancer"         
        }, {
          headers: {
            'Content-Type': 'application/json'
          }
        });
  
        if (response.status === 200 || response.status === 201) {
          alert('Registration successful!');
          console.log('Server response:', response.data);
          setFormData({
            name: '',
            email: '',
            password: '',
            confirmPassword: ''
          });
        }
      } catch (error) {
        if (error.response && typeof error.response.data === 'string') {
          alert(`Error: ${error.response.data}`);
        } else {
          alert('Registration failed. Please try again.');
        }
        console.error('Registration error:', error);
      }
    }
  };
  

  return (
    <div className='flex flex-col items-center lg:flex-row justify-center mx-10 my-40 gap-16'>
      <img src={serviceGroup} alt="service-group" className='hidden lg:flex'/>
      <div className='flex flex-col'>
        <form onSubmit={handleSubmit} className='flex flex-col gap-3'>
          <div className='flex items-center gap-2 cursor-pointer'> 
            <img src={leftSign} alt="left-sign" />
            <a href='#' className='text-[#00000080] font-poppins hover:underline'>Back to Home</a>    
          </div>

          <div className='flex items-center justify-center gap-5 flex-col md:flex-row'>
            <h1 className='text-6xl text-[#216F4C] font-poppins font-medium flex flex-row'>Sign Up</h1>
            <img src={vertical} alt="vertical" className='hidden xl:flex' />
            <img src={logo} alt="logo"/>
          </div>

          <label htmlFor="name" className='font-poppins text-[#00000080] text-lg'>Full Name</label>
          <input 
            type="text" 
            name="name"
            placeholder='Enter Full Name' 
            className={`border rounded-full p-3 border-[#216F4C] ${errors.name ? 'border-red-500' : ''}`}
            value={formData.name}
            onChange={handleChange}
          />
          {errors.name && <p className="text-red-500 text-sm -mt-2">{errors.name}</p>}

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

          <label htmlFor="confirmPassword" className='font-poppins text-[#00000080] text-lg'>Confirm Password</label>
          <input 
            type="password" 
            name="confirmPassword"
            placeholder='Confirm Password' 
            className={`border rounded-full p-3 border-[#216F4C] ${errors.confirmPassword ? 'border-red-500' : ''}`}
            value={formData.confirmPassword}
            onChange={handleChange}
          />
          {errors.confirmPassword && <p className="text-red-500 text-sm -mt-2">{errors.confirmPassword}</p>}

          <button 
            type="submit"
            className='bg-[#216F4C] self-center w-[70%] p-2 text-white font-poppins rounded-full mt-5 hover:bg-[#2a9464]'
          >
            Sign Up
          </button>

          <div className='flex items-center justify-center gap-2 text-[#00000080]'>
            <p>Have an account? </p>
            <a className='text-[#216F4C] font-semibold font-poppins hover:underline' href="#">Log In</a>
          </div>
        </form>
      </div>
    </div>
  );
}

export default SignUp;
