import Navbar from '../Navbar/navbar';
import Footer from '../Footer/footer';
import Clock from "../../assets/Clock.png";
import Profilphoto from "../../assets/profil-photo.png";



function ClientStart(){
  return (
    <div>
      <Navbar />
      <div className="  flex items-center justify-center p-6">
    
      <div className="max-w-5xl w-full grid grid-cols-1 md:grid-cols-3 gap-8">
        {/* Left side: Main Form Section */}
        <div className="md:col-span-2 space-y-6">
          <div className="flex gap-2 flex-wrap text-sm text-gray-500">1/10 Create your profile <img src={Clock} alt="" /> 5-10 min</div>
          <h1 className="text-2xl font-semibold text-gray-800">
            How would you like to tell us about yourself?
          </h1>
          <p className="text-sm text-gray-600">
            We need to get a sense of your education, experience and skills. It’s quickest to
            import your information — you can edit it before your profile goes live.
          </p>
          <div className="flex flex-col sm:flex-row gap-4">
            <button className="px-4 py-2 border border-[#216F4C] text-[#216F4C] rounded-md  hover:bg-[#216F4C] hover:text-white">
              Start Configure
            </button>
            <button className="px-4 py-2 border border-[#216F4C] text-[#216F4C] rounded-md hover:bg-[#216F4C] hover:text-white">
              Start Configure like Company
            </button>
          </div>
        </div>

        {/* Right side: Quote Section */}
        <div className="flex flex-col gap-3 bg-gray-50 p-4 rounded-lg border border-gray-200 shadow-sm">
          <div className="flex items-center space-x-3 ">
            <img src={Profilphoto} alt="" />
          </div>
          <p className="text-sm text-[#181818] font-medium ">
          “Your NextJob profile is
            how you stand out from the
            crowd.It’s what you use to
            win work, so let’s make it a
            good one.”
          </p>
          <span className="text-sm font-medium text-gray-700 ">NextJob Pro Tip</span>
        </div>
      </div>
    </div>

      <Footer />
    </div>
  );
}

export default ClientStart;
