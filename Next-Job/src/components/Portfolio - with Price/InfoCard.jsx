import React from "react";

function InfoCard({  title, subtitle }) {
  return (
    <div className="flex items-center gap-3 p-4 bg-white shadow-md rounded-lg">
      {/* Ikona */}
     <div className="">

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
