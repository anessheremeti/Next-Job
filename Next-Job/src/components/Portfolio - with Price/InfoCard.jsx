import React from "react";

function InfoCard({ Icon, title, subtitle }) {
  return (
    <div className="flex items-center gap-3 p-4 ">
      {/* Ikona */}
      <div className="p-2 bg-[#FBF7ED] rounded-full text-green-700">
       <img  src={Icon} alt="" />
      </div>

      {/* Teksti */}
      <div>
        <h4 className="text-sm font-semibold text-gray-800">{title}</h4>
        <p className="text-xs text-gray-500">{subtitle}</p>
      </div>
    </div>
  );
}

export default InfoCard;
