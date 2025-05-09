import { useState } from "react";
import Navbar from '../Navbar/navbar';
import Footer from '../Footer/footer';
import UploadMedia from "./UploadMedia";

export default function AddPortfolio() {
  const [formData, setFormData] = useState({
    title: "",
    role: "",
    description: "",
    skills: "",
  });

  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
    setErrors({ ...errors, [e.target.name]: "" }); // clear error on input
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const newErrors = {};
    if (!formData.title.trim()) newErrors.title = "Project title is required";
    if (!formData.description.trim())
      newErrors.description = "Project description is required";
    if (!formData.skills.trim())
      newErrors.skills = "Skills and deliverables are required";

    setErrors(newErrors);

    if (Object.keys(newErrors).length === 0) {
      console.log("Form submitted:", formData);
      // submit to backend or clear the form
    }
  };

  return (
    <div className=" mx-auto p-6">
<Navbar/>
     <div className='w-[87%] m-auto'>
          <h2 className="text-3xl font-bold">
              Add a new <span className="text-green-600">portfolio</span> project
            </h2>
            <p className="text-sm text-gray-500 mt-1">
              All fields are required unless otherwise indicated.
            </p>

            <form className="flex flex-col mt-6 space-y-5" onSubmit={handleSubmit}>
              <div className="flex flex-col gap-5">
               <div>
               <input
                  type="text"
                  name="title"
                  placeholder="Enter a brief but descriptive title"
                  className="w-full border border-gray-300 p-3 rounded-lg focus:outline-none focus:ring-2 focus:ring-green-500"
                  value={formData.title}
                  onChange={handleChange}
                />
                {errors.title && <p className="text-red-500 text-sm">{errors.title}</p>}
              </div>

              <div className="flex flex-row flex-wrap gap-5">
                  <div className="flex flex-col gap-5 flex-grow">
                  <div>
                  <input
                    type="text"
                    name="role"
                    placeholder="e.g., Front-end Developer"
                    className="w-full border border-gray-300 p-3 rounded-lg focus:outline-none focus:ring-2 focus:ring-green-500"
                    value={formData.role}
                    onChange={handleChange}
                  />
                </div>

                <div>
                  <textarea
                    name="description"
                    placeholder="Briefly describe the project’s goals, your solution and the impact you made here"
                    className="w-full border border-gray-300 p-3 rounded-lg focus:outline-none focus:ring-2 focus:ring-green-500"
                    rows="4"
                    value={formData.description}
                    onChange={handleChange}
                  />
                  {errors.description && (
                    <p className="text-red-500 text-sm">{errors.description}</p>
                  )}
                </div>

                <div>
                  <input
                    type="text"
                    name="skills"
                    placeholder="Type to add skills relevant to this project"
                    className="w-full border border-gray-300 p-3 rounded-lg focus:outline-none focus:ring-2 focus:ring-green-500"
                    value={formData.skills}
                    onChange={handleChange}
                  />
                  {errors.skills && (
                    <p className="text-red-500 text-sm">{errors.skills}</p>
                  )}
                </div>
                    
                  </div>
                    <div className="flex-grow"><UploadMedia/> </div>
               </div>

              {/* Media upload placeholder */}
                
              

              </div>
              <button
                type="submit"
                className="bg-green-600 text-white px-6 py-2 rounded-lg hover:bg-green-700 w-[170px]"
              >
                Submit Project
              </button>
            </form>
     </div>
      <Footer/>
    </div>
  );
}
