const ActivityItem = ({ icon, taskName, taskStatus, timeAgo }) => {
    return (
      <div className="item_one flex items-center justify-between place-content-between ">
        <li className="flex pt-10 gap-5 justify-between">
          <div className="pt-1">
          <img className="w-7 h-7" src={icon} alt="Task" />
          </div>
          
          <p className="pt-2">
            Task <span className="text-green-500">{taskName}</span> was {taskStatus}
          </p>
        </li>
        <button
          type="button"
          className="bg-gray-200 text-sm text-gray-700 px-4 py-2 mt-10 hover:bg-gray-300 transition duration-200 ease-in-out"
        >
          {timeAgo}
        </button>
      </div>
    );
  };
  
  export default ActivityItem;
  