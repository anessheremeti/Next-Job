import Arrow from "../../assets/arrow.png";
function AddReitew() {
  

    return (
        <div className=" flex flex-col flex-wrap gap-4  items-start   mx-auto px-4 py-8 bg-white">
        <h2 className=" text-xl font-semibold mb-2">Add a Review</h2>
        <p className="text-sm text-gray-500 mb-4">
          Your email address will not be published. Required fields are marked *
        </p>
      
        <label className="block mb-1 font-medium text-gray-700">Your rating of this product</label>
        <div className="flex space-x-1 mb-4">
          <span className="text-gray-300 text-2xl cursor-pointer">&#9733;</span>
          <span className="text-gray-300 text-2xl cursor-pointer">&#9733;</span>
          <span className="text-gray-300 text-2xl cursor-pointer">&#9733;</span>
          <span className="text-gray-300 text-2xl cursor-pointer">&#9733;</span>
          <span className="text-gray-300 text-2xl cursor-pointer">&#9733;</span>
        </div>
      
        <form className="space-y-4 ">
          <div className='flex flex-col flex-wrap gap-4'>
            <label className="block mb-1 font-medium text-gray-700">Comment *</label>
            <textarea
              rows="5"
              className=" w-full max-w-[888px] mx-auto  border border-gray-300 rounded p-3 focus:outline-none focus:ring-2 focus:ring-green-400"
              placeholder="Write your review here..."
              required
            ></textarea>
          </div>
      
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div>
              <label className="block mb-1 font-medium text-gray-700">Name *</label>
              <input
                type="text"
                className="w-full border border-gray-300 rounded p-2 focus:outline-none focus:ring-2 focus:ring-green-400"
                placeholder="Your name"
                required
              />
            </div>
            <div>
              <label className="block mb-1 font-medium text-gray-700">Email *</label>
              <input
                type="email"
                className="w-full border border-gray-300 rounded p-2 focus:outline-none focus:ring-2 focus:ring-green-400"
                placeholder="you@example.com"
                required
              />
            </div>
          </div>
      
          <div className="flex items-center space-x-2">
            <input type="checkbox" id="save" className="accent-green-500" />
            <label htmlFor="save" className="text-sm text-gray-700">
              Save my name, email, and website in this browser for the next time I comment.
            </label>
          </div>
      
        
              <button className=" bg-[#5BBB7B1A] text-[#5BBB7B] font-semibold px-6 py-2 rounded flex flex-row items-center gap-2 hover:bg-[#3c6f4d1a] transition">
                Send <img src={Arrow} alt="" />
              </button>
        </form>
      </div>
    );
  }
  
  export default AddReitew;


