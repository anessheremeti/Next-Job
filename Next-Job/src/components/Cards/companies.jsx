import React from 'react'
import arrayRight from "../../assets/array-right.png";
import focusedLogo from "../../assets/focused-logo.png";
import location from "../../assets/location.png";

function Companies() {
  return (
    <div className='flex flex-col lg:flex-row justify-between items-center border border-[#216F4C] mx-4 lg:mx-20 p-4 rounded-xl gap-4'>
      <div className='flex flex-col lg:flex-row items-center justify-center gap-4 text-center lg:text-left'>
        <img src={focusedLogo} alt="focused-logo" />
        <div>
          <h4 className='font-poppins text-xl text-[#111827]'>Focused Studio</h4>
          <p className='font-poppins font-medium text-[#111827]'>Web Development & Design Company.</p>
        </div>
      </div>

      <button className='bg-[#216F4C] min-w-[160px] w-100 px-4 py-2 text-white font-poppins rounded-full text-center'>
        To Hire Somebody
      </button>

      <div className='flex flex-col gap-3 text-center lg:text-left'>
        <h3 className='font-poppins font-semibold'>FrontEnd Developer</h3>
        <p>HTML | CSS | JS | ReactJS </p>
        <div className='flex justify-center lg:justify-start items-center gap-2'>
          <img src={location} alt="location" />
          <p className='font-poppins'>Preshevë</p>
        </div>
      </div>
      <div className="flex justify-center items-center bg-[#216F4C] min-w-[160px] h-10 px-4 gap-2 text-white font-poppins rounded-full cursor-pointer">
        <p className='font-poppins text-sm'>APPLY NOW</p>
        <img src={arrayRight} alt="array-right" className='w-4 h-4' />
      </div>
    </div>
  //   <div className='flex flex-col xl:flex-row justify-between items-center border border-[#216F4C] mx-4 xl:mx-20 p-4 rounded-xl gap-4 w-full'>
  //   <div className='flex flex-col xl:flex-row items-center justify-center gap-4 text-center xl:text-left'>
  //     <img src={focusedLogo} alt="focused-logo" />
  //     <div>
  //       <h4 className='font-poppins text-xl text-[#111827]'>Focused Studio</h4>
  //       <p className='font-poppins font-medium text-[#111827]'>Web Development & Design Company.</p>
  //     </div>
  //   </div>
  
  //   <button className='bg-[#216F4C] min-w-[160px] w-100 px-4 py-2 text-white font-poppins rounded-full text-center'>
  //     To Hire Somebody
  //   </button>
  
  //   <div className='flex flex-col gap-3 text-center xl:text-left'>
  //     <h3 className='font-poppins font-semibold'>FrontEnd Developer</h3>
  //     <p>HTML | CSS | JS | ReactJS </p>
  //     <div className='flex justify-center xl:justify-start items-center gap-2'>
  //       <img src={location} alt="location" />
  //       <p className='font-poppins'>Preshevë</p>
  //     </div>
  //   </div>
  
  //   <div className="flex justify-center items-center bg-[#216F4C] min-w-[160px] h-10 px-4 gap-2 text-white font-poppins rounded-full cursor-pointer">
  //     <p className='font-poppins text-sm'>APPLY NOW</p>
  //     <img src={arrayRight} alt="array-right" className='w-4 h-4' />
  //   </div>
  // </div>
  

  

  )
}

export default Companies