import React from 'react'
import search from '../../assets/search.png'


function SearchBar() {
  return (
    <>
        <form action="" className='w-[70%] sm:w-[80%] md:w-[60%] lg:w-[35%]'>
            <div className='flex items-center border border-[#216F4C] rounded-md w-full px-2 sm:px-4 py-1 sm:py-2 gap-2 sm:gap-4'>
                <input 
                className='custom-search-input bg-transparent text-[#51545E] font-poppins w-full placeholder-[#51545E] focus:outline-none appearance-none text-sm sm:text-base [::-webkit-search-cancel-button]:appearance-none'  
                type="search" 
                placeholder='Search for any service | Find your Job | Find Companies'
                />
                <div className="search-btn cursor-pointer bg-[#216F4C] rounded-md p-2 sm:p-3 flex justify-center items-center min-w-[36px] min-h-[36px]">
                <img className='w-4 h-4 sm:w-5 sm:h-5' src={search} alt="search" />
                </div>
            </div>
        </form>
    </>
  )
}

export default SearchBar