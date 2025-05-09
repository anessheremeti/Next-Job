const InputWithIcon = ({ label, icon, placeholder, type = "text" }) => (
    <div>
      {label && <label className="block mb-2 text-sm font-medium text-gray-900">{label}</label>}
      <div className="relative">
        <img src={icon} className="absolute left-3 top-3 h-5 w-5" />
        <input type={type} className="w-full pl-10 p-2 border rounded-lg" placeholder={placeholder} />
      </div>
    </div>
  );
  
  export default InputWithIcon;
  