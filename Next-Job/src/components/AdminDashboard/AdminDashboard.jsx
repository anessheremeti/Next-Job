

import logo from "../../assets/Logo 1.png";          

import Aside from '../Aside/Aside';
import DummyData from "../InsightCardDummyData/InisghtCardDummyData";
import InsightCard from "../InsightCard/InsightCard";  
import WithDrawList from "../WithDrawList/WithDrawList";  
import ActivityList from "../ActivityList/ActivityList";
import Footer from '../Footer/footer'
const AdminDashboard = () => {
  return (
    <div className="container mx-auto px-3">
      <header className="flex items-center py-5">
        <img className="w-32 sm:w-36 object-contain" src={logo} alt="Logo" />
      </header>

      <div className="flex flex-col md:flex-row ">
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
