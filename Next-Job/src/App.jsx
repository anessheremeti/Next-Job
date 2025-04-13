import './App.css'
import AdminDashboard from './components/AdminDashboard/AdminDashboard'
import LandingPage from './components/LandingPage/landingpage'
import Withdrawal from "../src/withdrawal/Withdrawal.jsx";
import Card from "../src/components/Cards/card.jsx"
import Companies from './components/Cards/companies.jsx';
import Faq from '../src/components/FAQ/faq.jsx'

import PortfolioWithPrice from "../src/components/Portfolio - with Price/PortfolioWithPrice.jsx";

import UsersDashboard from './components/UsersDashboard/UserDashboard.jsx'
import FindTalent from './components/FindTalent/FindTalent.jsx'
import FindJobCompanies from './components/FindJobCompanies/FindJobCompanies.jsx';
import FindWork from './components/FindWork/FindWork.jsx';
import CompanyDashboard from './components/CompanyDashboard/CompanyDashboard.jsx';
import Workpage from "./components/WorkPage/WorkPage.jsx";
import MyJobs from './components/MyJobs/MyJobs.jsx';

function App() {

  return (
    <>
        {/* Ensar */}
        {/*<PortfolioWithPrice/>*/}
        {/* <Workpage/> */}
        <MyJobs/>

   

        {/* Blend */}
        {/* <LandingPage/> */}
        {/* <FindJobCompanies/> */}
        {/* <FindTalent/> */}
        {/* <FindWork/> */}
  

        {/* <CompanyDashboard/> */}
        {/* <Withdrawal/> */}
        {/* <AdminDashboard/> */}

    </>
  )
}

export default App;
