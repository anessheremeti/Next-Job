import Navbar from '../Navbar/navbar'
import Footer from '../Footer/footer'

import InfoCard from "../Portfolio - with Price/InfoCard";



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
      <div className="relative bg-[##F0EFEC] rounded-xl p-6 flex flex-col gap-4 shadow-md overflow-hidden">
        {/* Dekorimi i majtë */}
        <div className="absolute top-0 left-0 w-20 h-20 bg-[#75b699] rounded-br-full z-0" />

        {/* Dekorimi i djathtë */}
        <div className="absolute bottom-0 right-0 w-20 h-20 bg-green-900 rounded-tl-full z-0" />

        {/* Përmbajtja */}
        <div className="relative z-10">
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
    <div className="flex flex-wrap gap-6 justify-start p-6">
      <InfoCard  title="Delivery Time" subtitle="1-3 Days" />
      <InfoCard  title="English Level" subtitle="Professional" />
      <InfoCard  title="Location" subtitle="New York" />
    </div>

             <Footer/>
        </div>
    );    
}
export default PortfolioWithPrice;