import React,{useState} from 'react'
import logo from "../../assets/Logo 1.png";
import dot from "../../assets/dot.png";
import { Link } from "react-router";

import { AiOutlineClose,AiOutlineMenu} from "react-icons/ai";

function Navbar() {
    const [nav, setNav] = useState(false);
  
    const handleNav = () => {
      setNav(!nav);
    };
  
    return (
      <nav className='flex justify-between items-center pt-4 m-auto p-20 mt-5'>
        <img src={logo} alt="logo" />
  
        <ul className='hidden xl:flex justify-center items-center gap-4 border border-[#216F4C42] rounded-full'>
          <div className="li-ctn flex justify-center items-center gap-3 bg-[rgba(33,111,76,0.14)] py-2 px-4 rounded-full cursor-pointer ">
            <img src={dot} alt="dot" />
            <Link to="/find-talent"><li  className='current-list text-[#216F4C] font-poppins'>Find Talent</li></Link>
            
          </div>
          <div className="li-ctn flex justify-center items-center gap-3 py-2 px-4 cursor-pointer hover:bg-[rgba(33,111,76,0.14)] hover:rounded-full text-[#111827] hover:text-[#216F4C]  ">
            <img src={dot} alt="dot" />
            
            <Link to="/find-job-companies"><li  className=' font-poppins'>Companies</li></Link>
          </div>
          <div className="li-ctn flex justify-center items-center gap-3 py-2 px-4 cursor-pointer hover:bg-[rgba(33,111,76,0.14)] hover:rounded-full text-[#111827] hover:text-[#216F4C]  ">
            <img src={dot} alt="dot" />
            <Link to="/find-work"><li  className=' font-poppins'>Find Work</li></Link>
          </div>
        </ul>
  
        <div className="hidden xl:flex nav-buttons justify-center items-center gap-4">
          <button className='rounded-full px-7 py-2 border border-[#216F4C] text-[#216F4C] hover:bg-[rgba(33,111,76,1)] hover:text-white transition duration-300 font-poppins'>Log in</button>
          <button className='bg-[rgba(33,111,76,1)] text-white rounded-full px-7 py-2 hover:bg-[#ffffff] hover:text-[#216F4C] hover:border hover:border-[#216F4C] transition duration-300 font-poppins'>Register</button>
        </div>
  
        <div onClick={handleNav} className='cursor-pointer xl:hidden ps-5'>
          {nav ? <AiOutlineClose size={30} /> : <AiOutlineMenu size={30} />}
        </div>
  
        <div className={`${nav ? 'left-0' : '-left-full'} fixed top-0 w-[60%] h-full border-r border-r-[#216F4C] bg-[rgba(33,111,76)] ease-in-out duration-500 xl:hidden`}>
          <ul className='pt-24'>
            <li className='border-b border-b-[#ffffff] m-4 p-4'><a href="#" className='uppercase font-poppins font-bold text-[#ffffff]'>Find Talent</a></li>
            <li className='border-b border-b-[#ffffff] m-4 p-4'><a href="#" className='uppercase font-poppins font-bold text-[#ffffff]'>Companies</a></li>
            <li className='border-b border-b-[#ffffff] m-4 p-4'><a href="#" className='uppercase font-poppins font-bold text-[#ffffff]'>Find Work</a></li>
            <li className='border-b border-b-[#ffffff] m-4 p-4'><a href="#" className='uppercase font-poppins font-bold text-[#ffffff]'>Log in</a></li>
            <li className='border-b border-b-[#ffffff] m-4 p-4'><a href="#" className='uppercase font-poppins font-bold text-[#ffffff]'>Register</a></li>
          </ul>
        </div>
      </nav>
    );
  }
  
  export default Navbar;