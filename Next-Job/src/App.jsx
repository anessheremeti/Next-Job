import './App.css'
import AdminDashboard from './components/AdminDashboard/AdminDashboard'
import LandingPage from './components/LandingPage/landingpage'
import Withdrawal from "../src/withdrawal/Withdrawal.jsx";
import Card from "../src/components/Cards/card.jsx"
import Companies from './components/Cards/companies.jsx';
import Faq from '../src/components/FAQ/faq.jsx'
import UsersDashboard from './components/UsersDashboard/UserDashboard.jsx'
function App() {

  return (
    <>
      <UsersDashboard />
        {/* <Faq/> */}
    </>
  )
}

export default App;
