import React from 'react'
import Navbar from '../Navbar/navbar'
import Footer from '../Footer/footer'
import SearchBar from '../SearchBar/SearchBar'
import arrayRight from "../../assets/array-right.png";
import Card from '../Cards/card';

function FindTalent() {
  return (
    <>
        <Navbar/>
        <div className='flex flex-col items-center justify-center mx-5'>
            <p className='font-poppins text-center'>Development & IT | AI Services | Design & Creative | Sales & Marketing | Admin & Customer Support</p>
            <h1 className='flex flex-col text-center text-5xl font-monument mt-16 mb-10'><span>Search <span className='text-[#216F4C]'>more</span> about </span><span>your <span className='text-[#216F4C]'>project.</span></span></h1>
            <SearchBar/>
            <div className='mt-20 flex flex-col gap-10 mx-10'>
          <div className='grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-10'>
            <Card/>
            <Card/>
            <Card/>
            <Card/>
            <Card/>
            <Card/>
            <Card/>
            <Card/>
            <Card/>
            </div>

          <div className="flex justify-center items-center self-center bg-[#216F4C] w-150  py-2 px-5 gap-3 text-white font-poppins rounded-full cursor-pointer font-semibold ">
                <p>SHOW ALL</p>
                <img src={arrayRight} alt="array-right" />
          </div>
        </div>
        </div>
        <Footer/>
    </>
  )
}

export default FindTalent