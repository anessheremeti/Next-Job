import logo from "../../src/assets/Logo 1.png";
import jobs from "../../src/assets/Symbol (4).png";
import dashboard from "../../src/assets/Symbol (8).png";
import InsightCard  from "../InsightCard/InsightCard";
import DummyData from '../InsightCardDummyData/InisghtCardDummyData'
import messages from '../../src/assets/Symbol (7).png'
import companies from '../../src/assets/Symbol (6).png'

import ActivityList from '../../ActivityList/ActivityList';
import WithDrawList from '../WithDrawList/WithDrawList';

const AdminDashboard = () => {
  return (
    <div className="container mx-auto px-3 sm:px-4 lg:px-8">
     <header className="flex items-center py-5">
  <img className="w-32 sm:w-36 object-contain" src={logo} alt="Logo" />
</header>


      <div className="main_content flex flex-col md:flex-row  pt-6">
        <div className="left_container flex-shrink-0 w-full md:w-64 flex flex-col gap-4">
          <div>
            <p className="text-green-600 font-semibold text-sm sm:text-base">Start</p>
            <ul className="flex flex-col gap-2 pt-1">
              <li className="flex items-center gap-2 text-sm sm:text-base">
                <img className="w-5 h-5 object-contain" src={dashboard} alt="Dashboard" />
                <span>Dashboard</span>
              </li>
              <li className="flex items-center gap-2 text-sm sm:text-base">
                <img className="w-5 h-5 object-contain" src={messages} alt="Messages" />
                <span>Messages</span>
              </li>
            </ul>
          </div>

          <div className="pt-4">
            <p className="text-green-600 font-semibold text-sm sm:text-base">Organize and Manage</p>
            <ul className="flex flex-col gap-2 pt-1">
              <li className="flex items-center gap-2 text-sm sm:text-base">
                <img className="w-6 h-6 object-contain" src={jobs} alt="Jobs" />
                <span>Jobs</span>
              </li>
              <li className="flex items-center gap-2 text-sm sm:text-base">
                <img className="w-6 h-6 object-contain" src={companies} alt="Companies" />
                <span>Companies</span>
              </li>
              <li className="flex items-center gap-2 text-sm sm:text-base">
                <img className="w-6 h-6 object-contain" src={dashboard} alt="Users" />
                <span>Users</span>
              </li>
            </ul>
          </div>
        </div>

        <div className="right_container flex-1">
          <div className="title ">
            <h1 className="text-3xl sm:text-4xl md:text-5xl font-bold">Hi Tom</h1>
            <p className="pt-2 sm:pt-3 text-gray-700 text-sm sm:text-base">We are glad to see you again!</p>
          </div>

          <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
            {DummyData.map((item, index) => (
              <InsightCard
                key={index}
                id={index}
                title={item.title}
                value={item.value}
                icon={item.icon}
                bgColor={item.bgColor}
              />
            ))}
          </div>
          <div className="activities_and_withdrawal_container grid grid-cols-1 sm:grid-cols-2 md:grid-cols-2 lg:grid-cols-2 gap-5 pt-6">
        <div className="activities p-4 flex flex-col gap-4">
          <ActivityList />
        </div>
        <div className="withdrawal p-4 flex flex-col gap-4">
          <WithDrawList />
        </div>
      </div>
        </div>
      </div>

      
    </div>
  );
};

export default AdminDashboard;
