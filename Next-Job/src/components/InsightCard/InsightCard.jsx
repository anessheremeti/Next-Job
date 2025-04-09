const InsightCard = (props) => {
    return (
      <div className="w-full bg-white shadow-md rounded-2xl p-6 flex items-center justify-between text-gray-800 hover:shadow-lg transition-shadow duration-300">
        <div className="flex flex-col">
          <p className="text-sm font-semibold mb-1">{props.title}</p>
          <span className="text-2xl font-bold">{props.value}</span>
        </div>
        <div style={{ backgroundColor: props.bgColor }} className={`h-12 w-12 flex items-center justify-center rounded-xl `}>
          <img
            src={props.icon}
            alt={props.title}
            className="w-6 h-6 object-contain"
          />
        </div>
      </div>
    );
  };
  
  export default InsightCard;
  