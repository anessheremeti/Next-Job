import React from 'react'
import Navbar from '../Navbar/navbar'
import Footer from '../Footer/footer'
import profileimg from "../../assets/image-profile.png"
import xvector from "../../assets/x-vector.png"


function DetailsSecond() {
  return (
    <>
        <Navbar/>
        <div className='flex flex-col lg:flex-row justify-center lg:items-start gap-16 my-10 mx-10 '>
            <div className='flex flex-col gap-4'>
                <h1 className='flex flex-col font-poppins font-semibold text-3xl'>Got it. Now, add a title, describtion and skills to <span>tell the world what you do.</span></h1>
                <p className='flex flex-col font-poppins font-semibold'>It’s the very first thing clients see, so make it count. Stand out by describing your expertise in your
                <span>own words.</span></p>
                <p className='flex flex-col font-poppins font-semibold'>Your professional role</p>
                <div className='flex justify-between items-center border border-[#8D8C8C] rounded-md px-2 py-2'>
                    <p className='font-poppins text-[#181818] font-semibold'>Ecommerce Development | Back-End Development, Product Development</p>
                    <img src={xvector} alt="cross" className='cursor-pointer' />
                </div>
                <p className='flex flex-col font-poppins font-semibold'>Your Description</p>
                <textarea name="description" placeholder='Enter description here' id="description" className='border h-[203px] border-[#8D8C8C] rounded-md px-2 py-2'>
                </textarea>
                <div className='flex justify-between items-center'>
                    <p className='flex flex-col font-poppins font-semibold'>Your skills</p>
                    <p className='font-poppins text-[#8D8C8C]'>Max 15 skills</p>
                </div>
                <div className='flex justify-between items-center border border-[#8D8C8C] rounded-md px-2 py-2'>
                    <p className='font-poppins text-[#8D8C8C] '>Enter skills here</p>
                </div>
                <button className='bg-[#216F4C] text-white py-2 rounded-lg font-poppins hover:bg-[#30986a]'>Finish</button>
            </div>
            <div className='w-[321px]  flex flex-col gap-4 justify-start items-start bg-[#F9F9F9] rounded-lg p-5 '>
                <img src={profileimg} alt="profile-img"/>
                <p className='font-poppins font-bold text-2xl'>“NextJob’s algorithm will
                recommend specific job
                posts to you based on your
                skills. So choose them
                carefully to get the best
                match!”
                </p>
                <p>NextJob Pro Tip</p>
            </div>
        </div>
        <Footer/>
    </>
  )
}

export default DetailsSecond
