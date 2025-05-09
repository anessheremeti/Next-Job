const BudgetCheckboxGroup = ({ selectedOption, onChange }) => {
    const options = ["fixed", "range", "negotiable"];
    const labels = {
      fixed: "Fixed Salary",
      range: "Salary Range",
      negotiable: "Negotiable",
    };
  
    return (
      <div className="flex gap-4 flex-wrap">
        {options.map(option => (
          <div key={option} className="flex items-center">
            <input
              type="radio"
              id={option}
              name="budget"
              className="mr-2"
              checked={selectedOption === option}
              onChange={() => onChange(option)}
            />
            <label htmlFor={option} className="text-sm">{labels[option]}</label>
          </div>
        ))}
      </div>
    );
  };
  
  export default BudgetCheckboxGroup;
  