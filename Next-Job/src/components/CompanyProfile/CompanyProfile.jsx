import Navbar from '../Navbar/navbar';
import Footer from '../Footer/footer';
import FindJobCards from '../Cards/FindJobCards';
import Testimonials from '../CompanyProfileWithEdits/Testimonials';
import YourPage from '../CompanyProfileWithEdits/YourPage';
import AddReitew from '../Portfolio - with Price/AddReitew';




function CompanyProfile() {
  

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
                <hr />
                <div>
                <AddReitew />
                </div>

                
            </div>     


      <Footer />
    </div>
  );
}

export default CompanyProfile;
