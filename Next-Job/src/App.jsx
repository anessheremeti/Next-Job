import './App.css'
import AdminDashboard from './components/AdminDashboard/AdminDashboard'
import LandingPage from './components/LandingPage/landingpage'
import Withdrawal from "../src/withdrawal/Withdrawal.jsx";
import Card from "../src/components/Cards/card.jsx"
import Companies from './components/Cards/companies.jsx';
import Faq from '../src/components/FAQ/faq.jsx'

import PortfolioWithPrice from "../src/components/Portfolio - with Price/PortfolioWithPrice.jsx";
import { BrowserRouter, Routes, Route } from "react-router";

import UsersDashboard from './components/UsersDashboard/UserDashboard.jsx'
import FindTalent from './components/FindTalent/FindTalent.jsx'
import FindJobCompanies from './components/FindJobCompanies/FindJobCompanies.jsx';
import FindWork from './components/FindWork/FindWork.jsx';
import CompanyDashboard from './components/CompanyDashboard/CompanyDashboard.jsx';
import Workpage from "./components/WorkPage/WorkPage.jsx";
import MyJobs from './components/MyJobs/MyJobs.jsx';
import ClientStart from './components/Client - Start/ClientStart.jsx';
import CompanyDetails from './components/Company Details/CompanyDetails.jsx';

function App() {

  return (
    <>
      <Routes>
        {/* Ensar */}
        <Route index element={<LandingPage />} />
        <Route path="/portfolio-with-price" element={<PortfolioWithPrice />} />
        <Route path="/workpage" element={<Workpage />} />
        <Route path="/my-jobs" element={<MyJobs />} />
        <Route path="/client-start" element={<ClientStart />} />
        <Route path="/company-details" element={<CompanyDetails />} />
        
        {/* Blend */}
        <Route path="/find-job-companies" element={<FindJobCompanies />} />
        <Route path="/find-talent" element={<FindTalent />} />
        <Route path="/find-work" element={<FindWork />} />
        
        {/* Company/Administration */}
        <Route path="/company-dashboard" element={<CompanyDashboard />} />
        <Route path="/withdrawal" element={<Withdrawal />} />
        <Route path="/admin-dashboard" element={<AdminDashboard />} />
        <Route path="/users-dashboard" element={<UsersDashboard />} />
      </Routes>
    </>
  );
}

export default App;
