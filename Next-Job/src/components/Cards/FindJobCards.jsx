import React from 'react'
import arrayRight from "../../assets/array-right.png";
import pseudoDot from "../../assets/pseudoDot.png";
import companyImg from "../../assets/company-img.png";


function FindJobCards() {
  return (
        <>
            <div className='flex flex-col gap-10 border border-[#216F4C] rounded-md py-4 px-6 w-full'>
                <div className='flex flex-col md:flex-row gap-16 items-center md:items-start '>
                    <div className='flex gap-5 items-center flex-col md:flex-row'>
                        <img src={companyImg} alt="company" />
                    <div className='flex flex-col gap-2 text-center md:text-left'>
                        <h2 className='font-poppins font-semibold text-xl'>Senior Receptionist</h2>
                        <p className='font-poppins '>Medico.co Ltd</p>
                    </div>
                    </div>
                    <div className='flex flex-col gap-2 text-center md:text-left'>
                    <div className='flex items-center gap-2 justify-center md:justify-start'>
                        <img src={pseudoDot} alt="dot" />
                        <p className='font-poppins'>
                        <span className='text-[#595959]'>Salary:</span>
                        <span className='text-[#061421] font-semibold'> $20K-$50K / </span>
                        <span className='text-[#595959]'>Per Month</span>

                        
                        </p>
                    </div>
                    <div className='flex items-center gap-2 justify-center md:justify-start'>
                        <img src={pseudoDot} alt="dot" />
                        <p className='font-poppins'>
                        <span className='text-[#595959]'>Deadline:</span>
                        <span className='text-[#061421] font-semibold'>05 April, 2023</span>
                        </p>
                    </div>
                    </div>
                </div>
                <div className='flex flex-col md:flex-row justify-between items-center md:items-start gap-5'>
                    <div className='flex flex-wrap gap-4 justify-center md:justify-start items-center'>
                    <button className='w-150 bg-[#DEDEDE] text-[#061421] font-sans font-semibold py-1 px-4 rounded-full'>
                        Youtube
                    </button>
                    <button className='w-150 bg-[#C0C0C02E] text-[#061421] font-sans font-semibold py-1 px-4 rounded-full'>
                        Design
                    </button>
                    <button className='w-150 bg-[#DEDEDE] text-[#061421] font-sans font-semibold py-1 px-4 rounded-full'>
                        Thumbnails
                    </button>
                    </div>
                    <div className='bg-[#216F4C] flex items-center gap-3 py-1 px-4 rounded-full self-center'>
                    <p className='font-poppins font-semibold text-white'>
                        Apply Now
                    </p>
                    <img src={arrayRight} alt="array" />
                    </div>
                </div>
            </div>
        </>
    )
}

export default FindJobCards