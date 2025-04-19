import Arrayright from "../../assets/array-right.png";
import Place from "../../assets/place.svg fill.png";
import Calendar from "../../assets/calendar.svg fill.png";
import Gender from "../../assets/gender.png";
import Languages from "../../assets/Languages.png";
import Sliders from "../../assets/sliders.svg.png";

export default function ClientInfoCard({
    location,
    memberSince,
    lastProject,
    gender,
    languages,
    country,
    onContact,
  }) {
    return (
      <div className="bg-white border  p-4 w-full max-w-xs shadow-sm">
        <h3 className="text-lg font-semibold text-gray-900 mb-4">Client Information</h3>
        <div className="space-y-3 text-sm text-gray-700 gap-2">
          <InfoRow image={Place} label="Location" value={location} />
          <InfoRow image={Calendar} label="Member since" value={memberSince} />
          <InfoRow image={Calendar} label="Last Project" value={lastProject} />
          <InfoRow image={Gender} label="Gender" value={gender} />
          <InfoRow image={Languages} label="Languages" value={languages} />
          <InfoRow image={Sliders} label="Country" value={country} />
        </div>
        <button
          onClick={onContact}
          className="mt-4 w-full bg-[#5BBB7B] text-white font-medium py-2 rounded-lg hover:bg-emerald-600 transition"
        >
          <div className="flex justify-center gap-2">
          Contact Now <img className="  items-center" src={Arrayright} alt="" />
          </div>
        </button>
      </div>
    );
  }
  
  // Component për çdo rresht infoje
  function InfoRow({ image, label, value }) {
    return (
      <div className="flex justify-between  items-center border-b pb-1 last:border-b-0 last:pb-0">
        <div className="flex gap-2 justify-center items-center" >
        <img className="h-[18px]" src={image} alt="" />
        <span className="text-[#222222]">{label}</span>
        </div>
        <span className="font-medium text-gray-900">{value}</span>
      </div>
    );
  }
  