import React, { useState } from 'react';
import Footer from '../Footer/footer';
import logo from "../../assets/Logo 1.png";
import client from "../../assets/client-img.png";
import freelancer from "../../assets/freelancer-img.png";

function Choose() {
  const [selectedRole, setSelectedRole] = useState(null);

  const handleSelect = (role) => {
    setSelectedRole(prev => (prev === role ? null : role)); 
  };

  return (
    <>
      <nav className='flex justify-between items-center pt-4 m-auto p-20 mt-5'>
        <img src={logo} alt="logo" />
      </nav>
      <h2 className='font-poppins font-bold text-center mb-6 text-2xl'>
        Join as client or freelancer
      </h2>
      <div className='flex flex-col md:flex-row justify-center items-center gap-5'>
        
        <div
          className='flex flex-col border border-[#8D8C8C] p-5 gap-5 rounded-lg w-[265px] cursor-pointer'
          onClick={() => handleSelect('client')}
        >
          <div className='flex justify-between'>
            <img src={client} alt="Client" />
            <div
              className={`w-5 h-5 border-2 rounded-full ring-1 ring-white ${
                selectedRole === 'client'
                  ? 'border-blue-500 bg-blue-500'
                  : 'border-gray-400'
              }`}
            />
          </div>
          <p className='flex flex-col font-poppins font-bold'>
            I'm a client, hiring for <span>a project</span>
          </p>
        </div>
        <div
          className='flex flex-col border border-[#8D8C8C] p-5 gap-5 rounded-lg w-[265px] cursor-pointer'
          onClick={() => handleSelect('freelancer')}
        >
          <div className='flex justify-between'>
            <img src={freelancer} alt="Freelancer" />
            <div
              className={`w-5 h-5 border-2 rounded-full ring-1 ring-white ${
                selectedRole === 'freelancer'
                  ? 'border-blue-500 bg-blue-500'
                  : 'border-gray-400'
              }`}
            />
          </div>
          <p className='flex flex-col font-poppins font-bold'>
            I'm a freelancer,<span>looking for work</span>
          </p>
        </div>
      </div>

      <div className='flex justify-center items-center mt-10'>
        <div className='flex flex-col justify-center'>
          <button className='border rounded-full bg-[#216F4C] text-white font-poppins hover:bg-transparent hover:text-[#216F4C] hover:border-[#216F4C] px-5 py-2'>
            Create Account
          </button>
          <div className='flex justify-center items-center gap-2 mt-5 font-poppins'>
            <p>Already have an account?</p>
            <a href="/signin" className='text-[#216F4C] underline font-bold'>Log in</a>
          </div>
        </div>
      </div>

      <Footer />
    </>
  );
}

export default Choose;
