const SelectWithIcon = ({ label, icon, options }) => (
    <div>
      <label className="block mb-2 text-sm font-medium text-gray-900">{label}</label>
      <div className="relative w-full">
        <img src={icon} className="absolute left-3 top-1/2 transform -translate-y-1/2 h-4 w-4 pointer-events-none" />
        <select className="w-full pl-10 pr-2 py-2 border rounded-lg appearance-none">
          {options.map(option => (
            <option key={option} value={option}>{option}</option>
          ))}
        </select>
      </div>
    </div>
  );
  
  export default SelectWithIcon;
  