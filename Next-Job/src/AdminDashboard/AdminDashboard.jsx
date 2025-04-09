import logo from "../../src/assets/Logo 1.png";
import jobs from "../../src/assets/Symbol (4).png";
import dashboard from "../../src/assets/Symbol (8).png";
import messages from '../../src/assets/Symbol (7).png';
import companies from '../../src/assets/Symbol (6).png';

import Aside from '../Aside/Aside';
import InsightCard from "../InsightCard/InsightCard";
import DummyData from '../InsightCardDummyData/InisghtCardDummyData';
import ActivityList from '../ActivityList/ActivityList';
import WithDrawList from '../WithDrawList/WithDrawList';

const AdminDashboard = () => {
  return (
    <div className="container mx-auto px-3">
      {/* Header */}
      <header className="flex items-center py-5">
        <img className="w-32 sm:w-36 object-contain" src={logo} alt="Logo" />
      </header>

      <div className="flex flex-col md:flex-row gap-6">
        <aside className="w-full md:w-1/4 lg:w-1/5">
          <Aside />

         
        </aside>

        <main className="flex-1">
          <div className="mb-6">
            <h1 className="text-3xl sm:text-4xl md:text-5xl font-bold">Hi Tom</h1>
            <p className="pt-2 sm:pt-3 text-gray-700 text-sm sm:text-base">
              We are glad to see you again!
            </p>
          </div>

          {/* Insight cards */}
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

          {/* Activities and Withdrawals */}
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-5 pt-6">
            <div className="activities p-4 flex flex-col gap-4">
              <ActivityList />
            </div>
            <div className="withdrawal p-4 flex flex-col gap-4">
              <WithDrawList />
            </div>
          </div>
        </main>
      </div>
    </div>
  );
};

export default AdminDashboard;
