


export function JobCard({ title, description, tags, salary, deadline, price, onClick }) {
    return (
      <div className="border rounded-md p-4 mb-4 shadow-sm ">
        <div className="flex justify-between items-start flex-wrap">
          {/* Përshkrimi i punës */}
          <div >
            <h3 className="font-semibold text-gray-800">{title}</h3>
            <p className="text-sm text-gray-500 mt-1">{description}</p>
  
            <div className="flex flex-wrap gap-2 mt-3">
              {tags.map((tag, idx) => (
                <span
                  key={idx}
                  className="bg-gray-100 text-gray-700 text-xs font-medium px-3 py-1 mb-2 rounded-full cursor-pointer"
                >
                  {tag}
                </span>
              ))}
            </div>
          </div>
          <div className="flex flex-row gap-6">
                <div className="flex flex-col ">
                <p className="text-xs text-gray-500 "> Salary: <span className="font-medium">{salary}</span></p>
                <p className="text-xs text-gray-500"> Deadline: <span className="font-medium">{deadline}</span></p>
                </div>
            </div>
  
          {/* Të dhënat teknike */}
          <div className=" text-left flex flex-col justify-end items-end gap-2 ">
           
            <div className="flex flex-col justify-end gap-4">
            <p className="text-xl font-semibold text-[#363636] mt-2 text-center">${price}</p>

                <button
                onClick={onClick}
                className="w-[145px] bg-[#216F4C] text-white px-4 py-1.5 rounded-full text-sm hover:bg-emerald-700 transition"
                >
                See More →
                </button>
            </div>
          </div>
        </div>
      </div>
    );
  }
  