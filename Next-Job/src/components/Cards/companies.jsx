import React from 'react'
import arrayRight from "../../assets/array-right.png";
import focusedLogo from "../../assets/focused-logo.png";
import location from "../../assets/location.png";

function Companies() {
  return (
     <div className='flex justify-between items-center  border border-[#216F4C] mx-20 p-4 rounded-xl'>
                  <div className='flex items-center justify-center gap-4'>
                    <img src={focusedLogo} alt="focused-logo" />
                    <div>
                      <h4 className='font-poppins text-xl text-[#111827]'>Focused Studio</h4>
                      <p className='font-poppins font-medium text-[#111827]'>Web Development & Design Company.</p>
                    </div>
                  </div>
                  <button className='bg-[#216F4C] px-4 py-1  text-white font-poppins rounded-full'>
                      To Hire Somebody
                  </button>
                  <div className='flex flex-col gap-3'>
                    <h3 className='font-poppins font-semibold'>FrontEnd Developer</h3>
                    <p>HTML | CSS| JS | ReactJS </p>
                    <div className='flex justify-start items-center gap-2'>
                      <img src={location} alt="location" />
                      <p className='font-poppins'>Preshevë</p>
                    </div>
                  </div>
                  <div className="flex justify-center items-center  bg-[#216F4C] w-[10%] p-2 gap-3 text-white font-poppins rounded-full cursor-pointer">
                      <p className='font-poppins'>APPLY NOW</p>
                      <img src={arrayRight} alt="array-right" />
                  </div>  
                </div>
  )
}

export default Companies