import React from 'react'

//Komponentat
import Navbar from '../Navbar/navbar'
import Footer from '../Footer/footer'
import Card from "../../components/Cards/card"
import Companies from '../../components/Cards/companies.jsx';
import Faq from '../../components/FAQ/faq.jsx'
import SearchBar from '../../components/SearchBar/SearchBar.jsx'
//Css
import './landigpage.css'

//Imazhet
import crown from '../../assets/king-crown.png';
import logo from "../../assets/Logo 1.png";
import arrayRight from "../../assets/array-right.png";
import buildings from "../../assets/buildings.png";
import heart from "../../assets/heart.png";
import job from "../../assets/job.png";
import chat from "../../assets/chat.png";
import faqimg from '../../assets/faq.png'




function landingpage() {
  return (
    <>
        <div className='bg-[#216F4C36] mx-5 rounded-3xl'>
          <Navbar/>
          <div className="connect-ctn flex flex-col justify-center items-center gap-7">
              <h1 className='flex flex-col text-center text-3xl lg:text-5xl font-monument mt-5'><span>We <span className='text-[#216F4C]'>connect</span> people to </span><span>bring ideas to <span className='text-[#216F4C]'>life</span></span> </h1>
              <p className='flex flex-col text-center text-[#111827] font-poppins'>Discover top talent or find jobs with AI-powered <span>tools that put you in control.</span></p>
              <SearchBar/>
              <div className=" popular-services flex justify-center gap-5 flex-wrap">
                  <button className='bg-[#216F4C] text-[#ffffff] font-poppins px-4 py-2 rounded-full hover:bg-transparent hover:text-[#216F4C] hover:border hover:border-[#216F4C]'>Web Development</button>
                  <button className='bg-[#216F4C] text-[#ffffff] font-poppins px-4 py-2 rounded-full hover:bg-transparent hover:text-[#216F4C] hover:border hover:border-[#216F4C]'>Web Design</button>
                  <button className='bg-[#216F4C] text-[#ffffff] font-poppins px-4 py-2 rounded-full hover:bg-transparent hover:text-[#216F4C] hover:border hover:border-[#216F4C]'>Video Editors</button>
                  <button className='bg-[#216F4C] text-[#ffffff] font-poppins px-4 py-2 rounded-full hover:bg-transparent hover:text-[#216F4C] hover:border hover:border-[#216F4C]'>Graphic Design</button>
                  <button className='bg-[#216F4C] text-[#ffffff] font-poppins px-4 py-2 rounded-full hover:bg-transparent hover:text-[#216F4C] hover:border hover:border-[#216F4C]'>Ai Services</button>
              </div>
              <a href="#" className='font-poppins text-[#111827] mb-28'>100+ More Popular Services</a>
          </div>
        </div>
        <div className="talents flex flex-col items-center justify-center gap-4 mt-16">
          <div className='flex items-center justify-center gap-3 border border-[#216F4C] px-4 py-2 rounded-full cursor-pointer'>
            <img src={crown} alt="" />
            <p className='text-[#216F4C]'>Most Popular</p>
          </div>
          <h1 className='text-6xl  font-poppins text-center'>Our <span className='text-[#216F4C]'>Most</span> Popular <span className='text-[#216F4C]'>Talents</span></h1>
        </div>
        <div className='mt-20 flex flex-col gap-10 mx-10'><div className='grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-20 lg:mx-20 '>
          <Card/>
          <Card/>
          <Card/>
          <Card/>
          <Card/>
          <Card/>

        </div>

          <div className="flex justify-center items-center self-center bg-[#216F4C] w-50 p-2 gap-3 text-white font-poppins rounded-full cursor-pointer">
                <p>SHOW ALL</p>
                <img src={arrayRight} alt="array-right" />
          </div>
        </div>
        <div className='bg-[#216F4C36] mx-5 rounded-3xl flex flex-col justify-center items-center p-10 mt-20'>
            <img src={logo} alt="logo" />
            <h1 className='flex flex-col justify-center items-start text-center text-3xl lg:text-5xl font-monument mt-10'>
              <span>The <span className='text-[#216F4C]'>premium</span> freelance</span>
              <span>solution for <span className='text-[#216F4C]'>businesses</span></span>
            </h1>
            <p className='text-center flex flex-col font-poppins text-[#111827] mt-8'>Join our platform to access skilled freelancers and effortlessly publish job opportunities. Our <span>AI-driven tools and dedicated support ensure a seamless hiring experience, so you can focus</span> on what matters—growing your business. Flexible payment options, advanced project <span>management, and a satisfaction guarantee make hiring easier than ever.</span></p>
            <div className="flex justify-center items-center self-center bg-[#216F4C] w-250 py-2 px-4 gap-3 text-white font-poppins rounded-full mt-14 cursor-pointer">
                  <p>Join Us</p>
                  <img src={arrayRight} alt="array-right" />
            </div>
        </div>
        <div className="talents flex flex-col items-center justify-center gap-4 mt-16">
          <div className='flex items-center justify-center gap-3 border border-[#216F4C] px-4 py-2 rounded-full cursor-pointer'>
            <img src={crown} alt="" />
            <p className='text-[#216F4C]'>Best Companies</p>
          </div>
          <h1 className='text-6xl  font-poppins text-center mb-5'>Our <span className='text-[#216F4C]'>Best</span> Popular <span className='text-[#216F4C]'>Companies</span></h1>
        </div>
        <div className="companies flex flex-col "><div className='hidden lg:flex justify-around mt-10 mb-8'>
        <div className='flex justify-center items-center gap-2 font-poppins font-semibold text-[#111827]'>
          <img src={buildings} alt="buildings"/>
          <p>Company Name</p>
        </div>
        <div className='flex justify-center items-center gap-2 font-poppins font-semibold text-[#111827]'>
          <img src={heart} alt="heart"/>
          <p>Looking For</p>
        </div>
        <div className='flex justify-center items-center gap-2 font-poppins font-semibold text-[#111827]'>
          <img src={job} alt="job"/>
          <p>Details</p>
        </div>
        <div>

        </div>
      </div>
          <div className='flex flex-col gap-10 flex-wrap mx-10'>
            <Companies/>
            <Companies/>
            <Companies/>
          </div>
          </div>
        <div className='bg-[#216F4C36] mx-5 rounded-3xl py-8 px-10 flex flex-col justify-center items-center gap-5 mt-20'>
            <h1 className=' text-3xl lg:text-4xl font-monument text-center'>Freelance <span className='text-[#216F4C]'>services</span> at your <span className='text-[#216F4C]'>fingertips</span></h1>
            <p className='font-poppins text-center'>Discover top talent or find jobs with AI-powered tools that put you in control.</p>
            <div className="flex justify-center items-center  bg-[#216F4C] w-150 py-2 px-4 gap-3 text-white font-poppins rounded-full cursor-pointer">
                  <p className='font-poppins font-semibold cursor-pointer'>Join Us</p>
                  <img src={arrayRight} alt="array-right" />
            </div>  
        </div>
        <div className="talents flex flex-col items-center justify-center gap-4 mt-16">
          <div className='flex items-center justify-center gap-3 border border-[#216F4C] px-4 py-2 rounded-full cursor-pointer'>
            <img src={chat} alt="chat" />
            <p className='text-[#216F4C]'>FAQ</p>
          </div>
          <h1 className='text-6xl  font-poppins flex flex-col items-center justify-center text-center'>Frquently Ask <span className='text-[#216F4C]'>Questions</span></h1>
        </div> 
        <div className='flex flex-col lg:flex-row justify-center gap-10 mt-10 mx-10'>
        <div className='flex flex-col gap-5 items-center lg:items-start text-center lg:text-left'>
          <img src={faqimg} alt="faq" className='w-150 lg:w-auto' />
          <h3 className='text-[#216F4C] text-3xl font-poppins'>Do you need help?</h3>
          <button className='bg-[#216F4C] py-2 px-7 rounded-full font-poppins text-white font-semibold hover:border hover:border-[#216F4C] hover:text-[#216F4C] hover:bg-transparent'>
            Contact Now
          </button>
        </div>

          <div className=''>
            <Faq/>
          </div>
        </div>
        <Footer/>
    </>
  )
}

export default landingpage