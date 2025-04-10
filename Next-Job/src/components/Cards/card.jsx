import React from 'react'
import cardTwo from "../../assets/card-2.png";
import profilePhoto from "../../assets/profil-photo.png";
import star from "../../assets/star.png";

function Card() {
  return (
    
<div className='flex justify-center items-center gap-10'>
              <div className='flex flex-col border border-[#216F4C] p-4 rounded-xl gap-4'>
                <img src={cardTwo} className='' alt="card-image" />
                <div className='flex items-center justify-between'>
                  <div className='flex items-center gap-3 text-[#4B5563] font-poppins'>
                    <img src={profilePhoto} alt="profile-photo" />
                    <p>Engjell Ajeti</p>
                  </div>
                  <div className='flex items-center gap-3'>
                    <img src={star} alt="star" />
                    <p className='font-poppins font-bold'>5.0</p>
                  </div>
                </div>
                <div className='flex flex-col gap-2'>
                  <h4 className='text-[#111827] font-semibold text-xl'>Web Design</h4>
                  <p className='flex flex-col text-[#4B5563] font-poppins'>
                  I will design or build responsive business <span>wordpress website development...</span>
                  </p>
                  <button className='flex self-start bg-[#216F4C] mt-3 text-white font-poppins px-5 py-1 rounded-full hover:bg-transparent hover:border hover:border-[#216F4C] hover:text-[#216F4C]'>
                    From: $65.00
                  </button>
                </div>
              </div>
          </div>
  )
}

export default Card