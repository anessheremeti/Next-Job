import Navbar from '../Navbar/navbar';
import Footer from '../Footer/footer';


function CompanyDetails() {
  

  return (
    <div>
      <Navbar />
      <div className="flex flex-col gap-5  max-w-4xl mx-auto p-6 ">
      <h2 className="text-2xl font-bold mb-3 max-w-[600px]">A few last details, then you can check and
      publish your profile.</h2>
      <p className='max-w-[708px]' >
      A professional photo helps you build trust with your clients. To keep things safe and simple, they’ll
      pay you through us - which is why we need your personal information.
      </p>
      <form className="space-y-6">
        <div className='flex flex-col gap-2 '>
        <label htmlFor="">Company name</label>
        <input type="text" placeholder="Company name" className="w-full p-3 border rounded-xl" defaultValue="Tom Wilson" />
        </div>

        <div className="flex flex-row flex-wrap gap-3">
         <div className='flex flex-col gap-2 flex-auto '>
         <label htmlFor="">Company Tagline (optional)</label>
         <input type="text" placeholder="Company Tagline" className="p-3 border rounded-xl" />
         </div>
          <div className="flex flex-col gap-2 flex-auto " >
          <label htmlFor="">Country (optional)</label>
          <select className="p-3 border rounded-xl">
            <option>Select Country</option>
          </select>
          </div>
        </div>
       <div className='flex flex-col gap-2 ' >
       <label htmlFor="">Industry (optional)</label>
        <select className="w-full p-3 border rounded-xl">
          <option>Industry</option>
        </select>
       </div>

        <div className=' flex flex-col gap-2'>
        <label >Company Logo (optional)</label>
            <div className='flex flex-auto p-3 border rounded-xl '>
          <input type="file" className="block w-full text-sm text-gray-500 file:mr-4 file:py-2 file:px-4 file:rounded-lg file:border file:border-gray-300 file:text-sm file:font-semibold file:bg-gray-100 hover:file:bg-gray-200" />
          <p className="text-xs text-gray-500 ">Maximum file size: 300 MB.</p>
            </div>
        </div>

        <div className="flex flex-row flex-wrap gap-3">
            <div className='flex flex-col gap-2 flex-auto'>
            <label htmlFor="">Company Website (optional)</label>
            <input type="url" placeholder="Company website" className="p-3 border rounded-xl" />
            </div>
            <div className='flex flex-col gap-2 flex-auto'>
            <label htmlFor="">Since (optional)</label>
            <input type="text" placeholder="Established date/year" className="p-3 border rounded-xl" />
            </div>
        </div>

        <div className="flex flex-row flex-wrap gap-3">
            <div className='flex flex-col gap-2 flex-auto'>        
            <label htmlFor="">Phone (optional)</label>
            <input type="tel" placeholder="Phone Number" className="p-3 border rounded-xl" />
            </div>
            <div className='flex flex-col gap-2 flex-auto'>
            <label htmlFor="">Email (optional)</label>
            <input type="email" placeholder="Email" className="p-3 border rounded-xl" defaultValue="tom@example.com" />
            </div>

        </div>
        <div className='flex flex-col gap-2 flex-auto'>
        <label htmlFor="">Short Description (optional)</label>
        <textarea placeholder="Short Description" className="w-full p-3 border rounded-xl min-h-[130px]"></textarea>
        </div>

        <div className='flex flex-col gap-2 flex-auto'>
        <label htmlFor="">Company Content (optional)</label>
        <textarea placeholder="Company Content" className="w-full p-3 border rounded-xl min-h-[150px]"></textarea>
        </div>

        <div className=' flex flex-col gap-2'>
        <label >Header Image (optional)</label>
            <div className='flex flex-auto p-3 border rounded-xl '>
          <input type="file" className="block w-full text-sm text-gray-500 file:mr-4 file:py-2 file:px-4 file:rounded-lg file:border file:border-gray-300 file:text-sm file:font-semibold file:bg-gray-100 hover:file:bg-gray-200" />
          <p className="text-xs text-gray-500 ">Maximum file size: 300 MB.</p>
            </div>
        </div>

        <button type="submit" className="w-full py-3 px-6 bg-[#216F4C] text-white rounded-xl hover:bg-white hover:text-[#216F4C] hover:border border-[#216F4C] transition">
          Save Company Profile
        </button>
      </form>
    </div>

      <Footer />
    </div>
  );
}

export default CompanyDetails;
