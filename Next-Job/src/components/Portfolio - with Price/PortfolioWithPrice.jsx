import Navbar from '../Navbar/navbar'
import Footer from '../Footer/footer'
import Calendar from "../../assets/calendar.svg fill.png";
import Finance from "../../assets/finance.svg fill.png";
import Place from "../../assets/place.svg fill.png";
import Nike from "../../assets/nike.png";
import SeandClock from "../../assets/sand-clock.svg fill.png";
import ClipPath from "../../assets/Clip path group.png";
import Dot from "../../assets/dot.png";
import Figure from "../../assets/Figure → service title.png";
import BruteRDP from "../../assets/BruteRDP.png";
import AboutSection from "../Portfolio - with Price/AboutSection";
import Arrow from "../../assets/arrow.png";

import ServiceCard from './ServiceCard';
import InfoCard from "../Portfolio - with Price/InfoCard";
import AddReitew from './AddReitew';



function PortfolioWithPrice() {
    return(
        <div>
             <Navbar/>

             <div className="p-6">
      {/* Kategoritë sipër */}
      <div className="text-center text-sm text-gray-700 mb-4">
        Development & IT | AI Services | Design & Creative | Sales & Marketing | Admin & Customer Support
      </div>

      {/* Kartela */}
      <div className="relative bg-[#F0EFEC] rounded-xl p-6 flex flex-col gap-4 shadow-md overflow-hidden min-h-[192.08px] justify-center">
        {/* Dekorimi i majtë */}
        <div className="absolute top-0 left-0 w-20 h-20 bg-[#75b699] rounded-br-full " />

        {/* Dekorimi i djathtë */}
        <div className="absolute bottom-0 right-0 w-20 h-20 bg-green-900 rounded-tl-full " />

        {/* Përmbajtja */}
        <div className="relative ">
          <h2 className="text-xl font-bold text-gray-800 mb-2">
            I will design website UI UX in adobe xd or figma
          </h2>

          <div className="flex flex-wrap items-center gap-4 text-sm text-gray-600">
            {/* Përdoruesi */}
            <div className="flex items-center gap-2">
              <img
                src="/your-profile-pic.jpg"
                alt="User"
                className="w-6 h-6 rounded-full object-cover"
              />
              <span className="font-medium text-gray-800">Jenny Wilson</span>
            </div>

            {/* Rating */}
            <div className="flex items-center gap-1">
              <span>⭐</span>
              <span>4.9</span>
              <span className="text-gray-400">· 94 reviews</span>
            </div>

            {/* Orders */}
            <div className="flex items-center gap-1">
              📦 <span>2 Orders in Queue</span>
            </div>

            {/* Views */}
            <div className="flex items-center gap-1">
              👁️ <span>902 Views</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  
    <div className='flex flex-row gap-20 justify-center flex-wrap'>
    <div className='flex flex-col gap-6'>
        {/*Cards*/}
      <div className="flex flex-wrap gap-6 justify-around p-6 ">
        <InfoCard Icon={Calendar} title="Delivery Time" subtitle="1-3 Days" />
        <InfoCard Icon={Finance} title="English Level" subtitle="Professional" />
        <InfoCard Icon={Place} title="Location" subtitle="New York" />
      </div>
      <img className='w-auto' src={Figure} alt="" />
      <div className=' flex flex-row flex-wrap gap-3'>
        <img className="w-[128px]" src={BruteRDP} alt="" /><img className="w-[128px]"  src={BruteRDP} alt="" /><img className="w-[128px]" src={BruteRDP} alt="" />
      </div>
    </div>
       {/*Base*/}
   <div>
   <div className="bg-white shadow-md rounded-lg p-6 w-full max-w-sm mx-auto mb-6 flex flex-col gap-3">
      <h2 className="text-gray-900 font-semibold text-lg mb-2">Basic</h2>
      <div class="w-full h-1 bg-gradient-to-r from-black to-transparent"></div>
      <h3 className="text-3xl font-bold text-gray-900 mb-1">$29</h3>
      <p className="text-gray-700 font-medium mb-2">High-converting Landing Pages</p>
      <p className="text-sm text-gray-500 mb-4">
        I will redesign your current landing page or create one for you (upto 4 sections)
      </p>

  <ul className="text-sm text-gray-700 space-y-2 mb-6 flex flex-col gap-2">
    <div className='flex flex-row gap-4'>
    <li className='flex flex-row gap-1'> <div className=' flex justify-center '><img className=' ' src={SeandClock} alt="" /> </div> 3 Days Delivery</li>
    <li className='flex flex-row gap-1'><div className=' flex justify-center '><img className=' ' src={ClipPath} alt="" /> </div>  2 Revisions</li>
    </div>
    <li className='flex flex-row gap-1'> <div className=' flex justify-center p-2 bg-[#5BBB7B26] rounded-full'><img className=' ' src={Nike} alt="" /> </div> 2 Page / Screen</li>
    <li className='flex flex-row gap-1'> <div className=' flex justify-center p-2 bg-[#5BBB7B26] rounded-full' ><img src={Nike} alt="" /> </div>Source file</li>
  </ul>

  <button className="bg-green-500 hover:bg-green-600 text-white font-medium py-2 px-4 rounded w-full">
    Continue $250
  </button>
</div>
   {/*seller*/}
   <div className="bg-white shadow-md rounded-lg p-6 w-full max-w-sm mx-auto flex flex-col gap-3">
  <h3 className="text-gray-900 font-semibold text-md mb-4">About The Seller</h3>

  <div className="flex items-center gap-4 mb-4">
    <div className="w-12 h-12 bg-gray-200 rounded-full"></div> {/* Vend për img */}
    <div>
      <p className="font-semibold text-gray-800">Jenny Wilson</p>
      <p className="text-sm text-gray-500">UI/UX Designer</p>
      <p className="text-yellow-500 text-sm font-medium">
        ⭐ 4.9 <span className="text-gray-500">(595 reviews)</span>
      </p>
    </div>
  </div>
  <hr className='w-[100%] '/>

  <div className=''>
  <ul className="flex flex-row gap-3 justify-around flex-wrap">
    {/* Location */}
    <li className="flex flex-col items-center">
      <div className='flex items-center gap-1'>
      <img className="" src={Dot} alt="Dot" />
      <span className="text-gray-700 font-medium">Location: </span>
      </div>
      
      <p className="text-gray-500">London</p>
    </li>

    {/* Employees */}
    <li className="flex flex-col items-center">
      <div className='flex items-center gap-1'>
      <img className="" src={Dot} alt="Dot" />
      <span className="text-gray-700 font-medium">Employees </span>
      </div>
      
      <p className="text-gray-500">11-20</p>
    </li>

    {/* Department */}
    <li className="flex flex-col items-center">
      <div className='flex items-center gap-1'>
      <img className="" src={Dot} alt="Dot" />
      <span className="text-gray-700 font-medium">Departments </span>
      </div>
      
      <p className="text-gray-500">Designer</p>
    </li>
  </ul>
</div>


  <button className="border border-green-500 text-green-600 hover:bg-green-50 font-medium py-2 px-4 rounded w-full hover:text-green-800 ">
    Contact Me
  </button>
</div>
   </div>
    </div>
    
    {/*Pjesa Tejte*/}

    <AboutSection/>
{/*Forma*/}
<div className='w-[87%] m-auto'>
<AddReitew/>
</div>
   
<div>
  <div className="w-[87%]  m-auto px-4 py-4 pt-14 ">

  
<h2 className="text-2xl font-semibold mb-4">People Who Viewed This Service Also Viewed</h2>
      <p className="text-gray-700 mb-6">
      Give your visitor a smooth online experience with a solid UX design      </p>
  </div>

<div className="my-8 flex flex-row gap-8 flex-wrap px-3 items-center justify-center mt-14 ">
      <ServiceCard
        image={BruteRDP}
        category="Web & App Design"
        title="I will design modern mobile app in figma or adobe xd"
        rating={4.82}
        reviews={94}
        name="Eleanor Pena"
        price={983}
      />
      <ServiceCard
  
  image={BruteRDP}  
  category="Web & App Design"
  title="I will design modern mobile app in figma or adobe xd"
  rating={4.82}
  reviews={94}
  name="Eleanor Pena"
  price={983}
/>
<ServiceCard
  image={BruteRDP}
  category="Web & App Design"
  title="I will design modern mobile app in figma or adobe xd"
  rating={4.82}
  reviews={94}
  name="Eleanor Pena"
  price={983}
/>
<ServiceCard
 image={BruteRDP}
  category="Web & App Design"
  title="I will design modern mobile app in figma or adobe xd"
  rating={4.82}
  reviews={94}
  name="Eleanor Pena"
  price={983}
/>

</div>

</div>


             <Footer/>
        </div>
    );    
}
export default PortfolioWithPrice;