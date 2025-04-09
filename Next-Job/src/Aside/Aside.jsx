import dashboard from "../../src/assets/Symbol (8).png";
import messages from '../../src/assets/Symbol (7).png'
import jobs from "../../src/assets/Symbol (4).png";
import companies from '../../src/assets/Symbol (6).png';

const Aside = () =>{
    return (
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
    )
}
export default Aside;