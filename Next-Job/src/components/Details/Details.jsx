// import React, { useRef, useState, useEffect } from 'react';
// import Navbar from '../Navbar/navbar';
// import Footer from '../Footer/footer';
// import addprofile from "../../assets/add-profile.png";
// import { Plus, CalendarDays, ChevronDown } from 'lucide-react';
// import PhoneInput from 'react-phone-input-2';
// import 'react-phone-input-2/lib/style.css';



// function Details() {
//   const dateInputRef = useRef(null);
//   const [formData, setFormData] = useState({
//     dob: '',
//     country: '',
//     street: '',
//     apt: '',
//     city: '',
//     state: '',
//     zip: '',
//     phone: '',
//   });
//   const [countries, setCountries] = useState([]);

//   useEffect(() => {
//     fetch('https://restcountries.com/v3.1/all')
//       .then(res => res.json())
//       .then(data => {
//         const sorted = data
//           .map(c => c.name.common)
//           .sort((a, b) => a.localeCompare(b));
//         setCountries(sorted);
//       });
//   }, []);

//   const handleChange = (e) => {
//     const { name, value } = e.target;
//     setFormData({ ...formData, [name]: value });
//   };

//   return (
//     <>
//       <Navbar />
//       <div className='flex  justify-center flex-col lg:mx-60  mx-10 lg:items-start items-center gap-10'>
//         <div className='flex flex-col gap-4'>
//           <h1 className='flex flex-col font-poppins text-bold text-3xl'>
//             A few last details, then you can check and
//             <span>publish your profile.</span>
//           </h1>
//           <p className='flex flex-col font-poppins text-bold'>
//             A professional photo helps you build trust with your clients. To keep things safe and simple, they’ll
//             <span>pay you through us - which is why we need your personal information.</span>
//           </p>
//         </div>

//         <div className='flex justify-center gap-10 flex-col lg:flex-row items-center lg:items-start'>
//           <div className='flex flex-col gap-6'>
//                 <img src={addprofile} alt="Profile Placeholder" />
//                 <button className="flex items-center gap-2 border border-green-700 text-green-700 font-semibold px-4 py-2 rounded-lg hover:bg-green-50 transition whitespace-nowrap min-w-[180px]">
//                 <Plus size={20} />
//                 <span className="font-poppins">Upload photo</span>
//                 </button>
//           </div>
//           <form className="flex flex-col gap-5 w-full max-w-3xl lg:items-start items-center">
//             <div>
//               <label className="font-semibold">Date of Birth *</label>
//               <div
//                 onClick={() => {
//                   dateInputRef.current?.showPicker?.();
//                   dateInputRef.current?.focus();
//                 }}
//                 className="flex items-center border border-gray-300 rounded-lg px-3 py-2 gap-2 w-fit bg-white cursor-pointer"
//               >
//                 <CalendarDays className="text-black w-5 h-5" />
//                 <input
//                   ref={dateInputRef}
//                   type="date"
//                   name="dob"
//                   value={formData.dob}
//                   onChange={handleChange}
//                   className="appearance-none text-gray-700 placeholder-gray-400 outline-none w-[130px] bg-transparent [&::-webkit-calendar-picker-indicator]:hidden"
//                   placeholder="yyyy-mm-dd"
//                 />
//                 <ChevronDown className="text-black w-4 h-4" />
//               </div>
//             </div>

//             <div className='flex flex-col gap-2 w-[57%] lg:w-[66%] '>
//               <label className="font-semibold">Country *</label>
//               <select
//                 name="country"
//                 value={formData.country}
//                 onChange={handleChange}
//                 className=":w-[66%]  border border-gray-300 rounded-lg px-3 py-2"
//               >
//                 <option value="">Select country</option>
//                 {countries.map((country) => (
//                   <option key={country} value={country}>{country}</option>
//                 ))}
//               </select>
//             </div>

//             <div className='flex flex-col lg:flex-row gap-4 max-w-none lg:w-full'>
//               <div className='flex-1  flex flex-col gap-2 '>
//                 <label className="font-semibold">Street address *</label>
//                 <input name="street" type="text" value={formData.street} onChange={handleChange} placeholder="Enter street address" className="w-full border border-gray-300 rounded-lg px-3 py-2" />
//               </div>
//               <div className='w-[200px] flex flex-col gap-2'>
//                 <label className="font-semibold">Apt/Suite</label>
//                 <input name="apt" type="text" value={formData.apt} onChange={handleChange} placeholder="Apt/Suite (Optional)" className="w-full border border-gray-300 rounded-lg px-3 py-2" />
//               </div>
//             </div>

//             <div className='flex flex-col lg:flex-row gap-4'>
//               <div className='flex-1 flex flex-col gap-2'>
//                 <label className="font-semibold">City *</label>
//                 <input name="city" type="text" value={formData.city} onChange={handleChange} placeholder="Enter city" className="w-full border border-gray-300 rounded-lg px-3 py-2" />
//               </div>
//               <div className='flex-1 flex flex-col gap-2'>
//                 <label className="font-semibold">State/Province *</label>
//                 <input name="state" type="text" value={formData.state} onChange={handleChange} placeholder="Enter state/province" className="w-full border border-gray-300 rounded-lg px-3 py-2" />
//               </div>
//               <div className='flex-1 flex flex-col gap-2'>
//                 <label className="font-semibold ">ZIP/Postal code *</label>
//                 <input name="zip" type="text" value={formData.zip} onChange={handleChange} placeholder="Enter ZIP/Postal code" className="w-full border border-gray-300 rounded-lg px-3 py-2" />
//               </div>
//             </div>

//             <div className='flex flex-col gap-2 max-w-none lg:w-[70%]'>
//               <label className="font-semibold">Phone *</label>
//               <PhoneInput
//                 country={'al'}
//                 value={formData.phone}
//                 onChange={(phone) => setFormData({ ...formData, phone })}
//                 inputProps={{
//                   name: 'phone',
//                   required: true,
//                   autoFocus: false,
//                 }}
//                 containerClass="w-full"
//                 inputClass="!w-full !h-[42px]"
//               />
//             </div>
//           </form>
//         </div>
//       </div>
//       <Footer />
//     </>
//   );
// }

// export default Details;
import React, { useRef, useState, useEffect } from 'react';
import Navbar from '../Navbar/navbar';
import Footer from '../Footer/footer';
import addprofile from "../../assets/add-profile.png";
import { Plus, CalendarDays, ChevronDown } from 'lucide-react';
import PhoneInput from 'react-phone-input-2';
import 'react-phone-input-2/lib/style.css';

function Details() {
  const dateInputRef = useRef(null);
  const [formData, setFormData] = useState({
    dob: '',
    country: '',
    street: '',
    apt: '',
    city: '',
    state: '',
    zip: '',
    phone: '',
  });

  const [formErrors, setFormErrors] = useState({});
  const [countries, setCountries] = useState([]);

  useEffect(() => {
    fetch('https://restcountries.com/v3.1/all')
      .then(res => res.json())
      .then(data => {
        const sorted = data
          .map(c => c.name.common)
          .sort((a, b) => a.localeCompare(b));
        setCountries(sorted);
      });
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const validate = () => {
    const errors = {};
    if (!formData.dob) errors.dob = 'Date of birth is required';
    if (!formData.country) errors.country = 'Country is required';
    if (!formData.street) errors.street = 'Street address is required';
    if (!formData.city) errors.city = 'City is required';
    if (!formData.state) errors.state = 'State/Province is required';
    if (!formData.zip) errors.zip = 'ZIP/Postal code is required';
    if (!formData.phone || formData.phone.length < 7) errors.phone = 'Valid phone number is required';
    return errors;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const errors = validate();
    setFormErrors(errors);
    if (Object.keys(errors).length === 0) {
      console.log('Form submitted:', formData);
    }
  };

  return (
    <>
      <Navbar />
      <div className='flex justify-center flex-col lg:mx-60 mx-10 lg:items-start items-center gap-10'>
        <div className='flex flex-col gap-4'>
          <h1 className='font-poppins font-bold text-3xl'>
            A few last details, then you can check and
            <span> publish your profile.</span>
          </h1>
          <p className='font-poppins font-medium'>
            A professional photo helps you build trust with your clients. To keep things safe and simple, they’ll
            <span> pay you through us - which is why we need your personal information.</span>
          </p>
        </div>

        <div className='flex justify-center gap-10 flex-col lg:flex-row items-center lg:items-start'>
          <div className='flex flex-col gap-6'>
            <img src={addprofile} alt="Profile Placeholder" />
            <button className="flex items-center gap-2 border border-green-700 text-green-700 font-semibold px-4 py-2 rounded-lg hover:bg-green-50 transition whitespace-nowrap min-w-[180px]">
              <Plus size={20} />
              <span className="font-poppins">Upload photo</span>
            </button>
          </div>

          <form onSubmit={handleSubmit} className="flex flex-col gap-5 w-full max-w-3xl lg:items-start items-center">
            <div className='w-full'>
              <label className="font-semibold">Date of Birth *</label>
              <div
                onClick={() => {
                  dateInputRef.current?.showPicker?.();
                  dateInputRef.current?.focus();
                }}
                className="flex items-center border border-gray-300 rounded-lg px-3 py-2 gap-2 w-fit bg-white cursor-pointer"
              >
                <CalendarDays className="text-black w-5 h-5" />
                <input
                  ref={dateInputRef}
                  type="date"
                  name="dob"
                  value={formData.dob}
                  onChange={handleChange}
                  className="appearance-none text-gray-700 outline-none w-[130px] bg-transparent [&::-webkit-calendar-picker-indicator]:hidden"
                />
                <ChevronDown className="text-black w-4 h-4" />
              </div>
              {formErrors.dob && <p className="text-red-500 text-sm">{formErrors.dob}</p>}
            </div>
            <div className='flex flex-col gap-2 w-full lg:w-[66%]'>
              <label className="font-semibold">Country *</label>
              <select
                name="country"
                value={formData.country}
                onChange={handleChange}
                className="border border-gray-300 rounded-lg px-3 py-2"
              >
                <option value="">Albania</option>
                {countries.map((country) => (
                  <option key={country} value={country}>{country}</option>
                ))}
              </select>
              {formErrors.country && <p className="text-red-500 text-sm">{formErrors.country}</p>}
            </div>

            <div className='flex flex-col lg:flex-row gap-4 w-full'>
              <div className='flex-1 flex flex-col gap-2'>
                <label className="font-semibold">Street address *</label>
                <input name="street" placeholder='Enter street address' type="text" value={formData.street} onChange={handleChange} className="w-full border border-gray-300 rounded-lg px-3 py-2" />
                {formErrors.street && <p className="text-red-500 text-sm">{formErrors.street}</p>}
              </div>
              <div className='w-[200px] flex flex-col gap-2'>
                <label className="font-semibold">Apt/Suite</label>
                <input name="apt" type="text" placeholder='Apt/Suite{Optional}' value={formData.apt} onChange={handleChange} className="w-full border border-gray-300 rounded-lg px-3 py-2" />
              </div>
            </div>

            <div className='flex flex-col lg:flex-row gap-4 w-full'>
              <div className='flex-1 flex flex-col gap-2'>
                <label className="font-semibold">City *</label>
                <input name="city" type="text" placeholder='Enter city' value={formData.city} onChange={handleChange} className="w-full border border-gray-300 rounded-lg px-3 py-2" />
                {formErrors.city && <p className="text-red-500 text-sm">{formErrors.city}</p>}
              </div>
              <div className='flex-1 flex flex-col gap-2'>
                <label className="font-semibold">State/Province *</label>
                <input name="state" type="text" placeholder='Enter state/province' value={formData.state} onChange={handleChange} className="w-full border border-gray-300 rounded-lg px-3 py-2" />
                {formErrors.state && <p className="text-red-500 text-sm">{formErrors.state}</p>}
              </div>
              <div className='flex-1 flex flex-col gap-2'>
                <label className="font-semibold">ZIP/Postal code *</label>
                <input name="zip" type="text" placeholder='Enter ZIP/Postal code' value={formData.zip} onChange={handleChange} className="w-full border border-gray-300 rounded-lg px-3 py-2" />
                {formErrors.zip && <p className="text-red-500 text-sm">{formErrors.zip}</p>}
              </div>
            </div>

            <div className='flex flex-col gap-2 w-full lg:w-[70%]'>
              <label className="font-semibold">Phone *</label>
              <PhoneInput
                country={'al'}
                value={formData.phone}
                onChange={(phone) => setFormData({ ...formData, phone })}
                inputProps={{
                  name: 'phone',
                  required: true,
                  autoFocus: false,
                }}
                containerClass="w-full"
                inputClass="!w-full !h-[42px]"
              />
              {formErrors.phone && <p className="text-red-500 text-sm">{formErrors.phone}</p>}
            </div>

            <button
              type="submit"
              className="bg-green-600 text-white px-6 py-2 rounded-lg font-semibold hover:bg-green-700 transition"
            >
              Submit
            </button>
          </form>
        </div>
      </div>
      <Footer />
    </>
  );
}

export default Details;
