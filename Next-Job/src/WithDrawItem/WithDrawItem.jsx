const WithdrawItem = ({ taskName, taskStatus, timeAgo }) => {
    return (
      <div className="tem_one flex items-center justify-between place-content-between">
        <li className="flex pt-10 gap-5 justify-between ">
          <p className=" pt-2">
            Task <span className="font-semibold">{taskName}</span> was {taskStatus}
          </p>
          <button
            type="button"
            className="bg-gray-200 text-sm text-gray-700 px-4 py-2  hover:bg-gray-300 transition duration-200 ease-in-out"
          >
            {timeAgo}
          </button>
        </li>
      </div>
    );
  };
  
  export default WithdrawItem;
  