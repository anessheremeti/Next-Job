import Arrow from "../../assets/arrow.png";
import Arrayright from "../../assets/array-right.png";


export default function JobPost() {
    return (
      <div className="flex flex-col md:flex-row justify-between items-center md:items-center border-b py-4 space-y-3 md:space-y-0  ">
        {/* Left side: Title & time */}
        <div className="flex flex-col items-start justify-start gap-3">
          <h2 className="text-lg font-semibold text-gray-900  ">
            YouTube Thumbnail Design <span className="text-gray-500">(Trial Project)</span>
          </h2>
          <p className="text-sm text-gray-500 mt-1">Posted 6 minutes ago</p>
        </div>
  
        {/* Right side: Tags, Button & Link */}
        <div className="flex flex-col md:items-end space-y-2 gap-3">
          {/* Tags and button */}
          <div className="flex flex-wrap items-center  justify-end gap-2">
            <span className="bg-gray-100 text-gray-700 text-xs font-medium px-4 py-2 mb-2  rounded-full">YouTube</span>
            <span className="bg-gray-100 text-gray-700 text-xs font-medium px-4 py-2 mb-2  rounded-full">Design</span>
            <span className="bg-gray-100 text-gray-700 text-xs font-medium px-4 py-2 mb-2  rounded-full">Thumbnails</span>
            <div className="pl-5">
            <button className="flex flex-row gap-2 bg-[#216F4C] text-white text-sm font-semibold px-5 py-2 rounded-full hover:bg-[#37b37b] transition">
              Apply Now <img className="w-[14px] h-[15px] text-white" src={Arrayright} alt="" />
            </button>
            </div>
          </div>
  
          {/* Job link */}
          <div className="text-sm text-gray-500 pt-3">
            <span className="mr-2">Job Link:</span>
            <span className="bg-emerald-100 text-emerald-800 px-4 py-1 rounded-full font-medium text-xs">
              NextJob.Com/Jobs/Youtubedesign
            </span>
          </div>
        </div>
      </div>
    );
  }
  