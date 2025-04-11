const InsightCard = (props) => {
  return (
    <div
      className="w-full bg-white shadow-md rounded-2xl p-6 flex items-center justify-between text-gray-800 
                 hover:shadow-xl hover:scale-[1.02] transition-transform duration-300 ease-in-out group cursor-pointer"
    >
      <div className="flex flex-col">
        <p className="text-sm font-semibold mb-1 group-hover:text-blue-600 transition-colors duration-300">
          {props.title}
        </p>
        <span className="text-2xl font-bold transition-colors group-hover:text-gray-900">
          {props.value}
        </span>
      </div>

      <div
        style={{ backgroundColor: props.bgColor }}
        className="h-12 w-12 flex items-center justify-center rounded-xl group-hover:rotate-6 transition-transform duration-300"
      >
        <img
          src={props.icon}
          alt={props.title}
          className="w-6 h-6 object-contain group-hover:scale-110 transition-transform duration-300"
        />
      </div>
    </div>
  );
};

export default InsightCard;
