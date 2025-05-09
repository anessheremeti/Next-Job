import Navbar from '../Navbar/navbar';
import Footer from '../Footer/footer';
import FindJobCards from '../Cards/FindJobCards';
import Testimonials from './Testimonials';
import YourPage from './YourPage';



function CompanyProfileWithEdits() {
  

  return (
    <div>
      <Navbar />
      <div className="text-center text-sm text-gray-700 mb-4">
        Development & IT | AI Services | Design & Creative | Sales & Marketing | Admin & Customer Support
      </div>
            <div className="flex flex-col gap-5  md:px-20 ">
                <YourPage />
                <FindJobCards />
                <FindJobCards />
                <FindJobCards />
                <Testimonials />
                
            </div>     


      <Footer />
    </div>
  );
}

export default CompanyProfileWithEdits;
