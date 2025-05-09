// JobPostFromAdmin.jsx
import { useState } from "react";
import Navbar from "../Navbar/navbar";
import InputWithIcon from "./InputWithIcon";
import SelectWithIcon from "./SelectWithIcon";
import BudgetCheckboxGroup from "./BudgetCheckboxGroup";
import jobTitleIcon from "../../assets/company-2.svg.png";
import jobCategoryIcon from "../../assets/category-2.svg.png";
import vacanciesIcon from "../../assets/user-2.svg.png";
import salaryIcon from "../../assets/salary-2.svg.png";
import emailIcon from "../../assets/email-2.svg.png";
import searchIcon from "../../assets/searchb.png";
import calendarIcon from "../../assets/calender2.svg.png";

const JobPostFromAdmin = () => {
  const [termsAccepted, setTermsAccepted] = useState(false);
  const [selectedOption, setSelectedOption] = useState("");

  const handleCheckboxChange = (value) => {
    setSelectedOption(prev => (prev === value ? "" : value));
  };

  return (
    <div>
      <Navbar />
      <div className="wrapper flex flex-col m-auto justify-center items-center">
        <div className="job_container border-2 border-deepGreen p-12 max-w-3xl w-full bg-white shadow-lg rounded-lg">
          <h2 className="text-xl font-semibold text-left mb-6">Job Information</h2>
          <div className="grid grid-cols-2 gap-6">
            <InputWithIcon label="Job Title" icon={jobTitleIcon} placeholder="Senior UI/UX Engineer" />
            <SelectWithIcon label="Job Category" icon={jobCategoryIcon} options={["FrontEnd", "BackEnd", "Video Editor", "UI/UX Designer"]} />

            <InputWithIcon label="Vacancies" icon={vacanciesIcon} placeholder="07 Person" />

            <div>
              <label className="block mb-2 text-sm font-medium text-gray-900">Budget Type</label>
              <BudgetCheckboxGroup selectedOption={selectedOption} onChange={handleCheckboxChange} />
              <InputWithIcon label="" icon={salaryIcon} placeholder="Enter Salary" />
            </div>

            <SelectWithIcon label="Job Type" icon={jobTitleIcon} options={["Full-Time", "Part-Time", "Remote", "Contract"]} />
            <InputWithIcon label="Experience Level" icon={emailIcon} placeholder="Enter Experience Level" />
            <InputWithIcon label="Job Tag" icon={searchIcon} placeholder="Enter Job Tags" />
            <InputWithIcon label="Deadline" icon={calendarIcon} type="date" />

            <div className="col-span-2">
              <label className="block mb-2 text-sm font-medium text-gray-900">Job Description</label>
              <textarea className="w-full p-2 border rounded-lg" rows={4} placeholder="Describe the job position in detail..." />
            </div>
          </div>

          <div className="flex items-center mt-4">
            <input type="checkbox" id="terms" className="mr-2" checked={termsAccepted} onChange={e => setTermsAccepted(e.target.checked)} />
            <label htmlFor="terms" className="text-sm">I agree to the Terms & Conditions</label>
          </div>

          <div className="text-center mt-6">
            <button
              className={`px-6 py-2 text-white rounded-lg flex ${termsAccepted ? "bg-deepGreen hover:bg-blue-700" : "bg-gray-400 cursor-not-allowed"}`}
              disabled={!termsAccepted}
            >
              Post Now
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default JobPostFromAdmin;
