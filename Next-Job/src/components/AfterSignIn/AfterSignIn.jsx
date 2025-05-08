import React from 'react'
import Navbar from '../Navbar/navbar'
import Footer from '../Footer/footer'
import clock from "../../assets/clock-img.png"
import profileimg from "../../assets/image-profile.png"

function AfterSignIn() {
  return (
    <>
        <Navbar/>
        <div className='flex flex-col lg:flex-row justify-center gap-16 my-10 mx-10 '>
            <div className='flex flex-col gap-4'>
                <div className='flex items-center gap-2 '>
                    <p className='text-[#181818]'>1/10 Create your profile</p>
                    <img src={clock} alt="clock"/>
                    <p className='text-[#676767] font-poppins'>5-10 min</p>
                </div>
                <h1 className='font-poppins font-bold text-4xl'>How would you like to tell us about yourself?</h1>
                <p className='flex flex-col font-poppins font-semibold'>We need to get a sense of your education, experience and skills. It’s quickest to import your
                <span>information — you can edit it before your profile goes live.</span></p>
                <button className='font-poppins py-2 border border-[#216F4C] text-[#216F4C] bg-transparent hover:bg-[#216F4C] hover:text-white rounded-lg'>Start Configure</button>
            </div>
            <div className='w-[321px]  flex flex-col gap-4 justify-start items-start bg-[#F9F9F9] rounded-lg p-5 self-center'>
                <img src={profileimg} alt="profile-img"/>
                <p className='font-poppins font-bold text-2xl'>“Your NextJob profile is
                    how you stand out from the
                    crowd.It’s what you use to
                    win work, so let’s make it a
                    good one.”
                </p>
                <p>NextJob Pro Tip</p>
            </div>
        </div>
        <Footer/>
    </>
  )
}

export default AfterSignIn