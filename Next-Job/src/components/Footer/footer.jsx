import React from 'react'
import logo from "../../assets/Logo 1.png";

function Footer() {
  return (
    <div className='m-auto p-20'>
        <div className='footer-ctn flex md:flex-row flex-col justify-between items-center gap-20'>
            <div className='flex flex-col gap-5'>
                <img src={logo} className='w-[60%]' alt="logo"/>
                <p className='flex flex-col text-[#111827]  font-poppins'>NextJob offers seamless and secure platform solutions designed <span>for freelancers, enabling you to easily connect with clients, showcase </span>your skills, and scale your business with confidence.</p>
            </div>
            <div className="pages flex justify-center gap-20 ">
                <div className="main-pages">
                    <ul>
                        <li className='text-[#111827]  font-poppins font-semibold'>Main Pages</li>
                        <li><a href="#" className='text-[#6B7280] font-poppins'>Home</a></li>
                        <li><a href="#" className='text-[#6B7280] font-poppins'>Features</a></li>
                        <li><a href="#" className='text-[#6B7280] font-poppins'>Pricing</a></li>
                        <li><a href="#" className='text-[#6B7280] font-poppins'>FAQs</a></li>
                    </ul>
                </div>
                <div className="main-pages">
                <ul>
                        <li className='text-[#111827]  font-poppins font-semibold'>Company</li>
                        <li><a href="#" className='text-[#6B7280] font-poppins'>Terms Of Services</a></li>
                        <li><a href="#" className='text-[#6B7280] font-poppins'>Contact</a></li>
                        <li><a href="#" className='text-[#6B7280] font-poppins'>Blog</a></li>
                        <li><a href="#" className='text-[#6B7280] font-poppins'>Privacy Policy</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div className='md:flex-row flex-col flex gap-10  border-t-2 border-t-[#D1E0FF] mt-10  justify-between items-center pt-7 '>
            <p className='text-[#111827]  font-poppins text-center'>
                © 2025 Copyright  | Powered by <span className='text-[#216F4C]'>FocusedStudio</span>
            </p>
            <button className='border bg-transparent hover:bg-transparent border-[#216F4C] hover:text-[#ffffff]hover:border hover:border-[#216F4C] hover:bg-[#216F4C] px-5 py-3 rounded-full text-[#216F4C]font-poppins font-semibold'>
                    Back To Top
            </button>
        </div>
    </div>
  )
}

export default Footer