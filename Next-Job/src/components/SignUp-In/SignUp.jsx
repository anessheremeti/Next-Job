import React from 'react'
import leftSign from "../../assets/left-sign.png"
import vertical from "../../assets/vertical.png"
import logo from "../../assets/Logo 1.png";
import serviceGroup from "../../assets/service-group.png";




function SignUp() {
  return (
    <div className='flex flex-col items-center lg:flex-row justify-center  mx-10 my-40 gap-16'>
        <img src={serviceGroup} alt="service-group" className='hidden lg:flex'/>
        <div className='flex flex-col'>
            <form action="#" className='flex flex-col gap-3'>
                <div className='flex items-center gap-2 cursor-pointer'> 
                    <img src={leftSign} alt="left-sign" />
                    <a href='#' className='text-[#00000080] font-poppins hover:underline'>Back to Home</a>    
                </div>
                <div className='flex items-center justify-center gap-5 flex-col md:flex-row'>
                    <h1 className='text-6xl text-[#216F4C] font-poppins font-medium flex flex-row'>Sign Up</h1>
                    <img src={vertical} alt="vertical" className='hidden xl:flex ' />
                    <img src={logo}  alt="logo"/>
                </div>
                <label htmlFor="Name" className='font-poppins text-[#00000080] text-lg'>Full Name</label>
                <input type="text" placeholder='Enter Full Name' className='border rounded-full p-3 border-[#216F4C]' />
                <label htmlFor="email" className='font-poppins text-[#00000080] text-lg'>Email</label>
                <input type="email" placeholder='Enter Email' className='border rounded-full p-3 border-[#216F4C]' />
                <label htmlFor="password" className='font-poppins text-[#00000080] text-lg'>Password</label>
                <input type="password" placeholder='Enter Password'  className='border rounded-full p-3 border-[#216F4C]' />
                <label htmlFor="password" className='font-poppins text-[#00000080] text-lg'>Confirm Password</label>
                <input type="password" placeholder='Enter Password' className='border rounded-full p-3 border-[#216F4C]' />
                <button className='bg-[#216F4C] self-center w-[70%] p-2 text-white font-poppins rounded-full mt-5 hover:bg-[#2a9464]'>Sign Up</button>
                <div className='flex items-center justify-center gap-2 text-[#00000080]'><p>Have an account? </p><a className='text-[#216F4C] font-semibold font-poppins  hover:underline' href="#">Log In</a></div>
            </form>
        </div>
    </div>
  )
}

export default SignUp