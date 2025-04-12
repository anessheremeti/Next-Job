import logo from '../../assets/Logo 1.png'

function Foter(){

    return(
        <footer className="bg-white border-t mt-10 mx-12">
        <div className=" mx-0 px-4 py-10">
          <div className="flex flex-col md:flex-row md:justify-between md:items-start text-left space-y-10 md:space-y-0 md:space-x-16">
            <div className="md:w-1/3">
              <div className="flex items-center space-x-2 mb-4">
                <img src={logo} alt="NextJob Logo" className="w-6 h-6" />
                <h2 className="text-xl font-bold text-gray-800">NextJob</h2>
              </div>
              <p className="text-sm text-gray-600">
                SwiftRDP delivers reliable, private, and secure hosting solutions tailored to your unique use case.
              </p>
            </div>
      
            <div className="flex flex-col md:flex-row md:justify-between md:items-start text-left space-y-10 md:space-y-0 md:space-x-16 px-14">
                <div>
                <h4 className="text-md font-semibold text-gray-800 mb-3">Main Pages</h4>
                <ul className="space-y-2 text-sm text-gray-600">
                    <li><a href="#" className="hover:text-green-600">Home</a></li>
                    <li><a href="#" className="hover:text-green-600">Features</a></li>
                    <li><a href="#" className="hover:text-green-600">Pricing</a></li>
                    <li><a href="#" className="hover:text-green-600">FAQs</a></li>
                </ul>
                </div>
        
                <div className="">
                <h4 className="text-md font-semibold text-gray-800 mb-3">Company</h4>
                <ul className="space-y-2 text-sm text-gray-600">
                    <li><a href="#" className="hover:text-green-600">Terms Of Services</a></li>
                    <li><a href="#" className="hover:text-green-600">Contact</a></li>
                    <li><a href="#" className="hover:text-green-600">Blog</a></li>
                    <li><a href="#" className="hover:text-green-600">Privacy Policy</a></li>
                </ul>
                </div>
            </div>
          </div>
        </div>
      
        <div className="border-t pt-6 pb-4 px-4 flex flex-col md:flex-row justify-between items-center  mx-0 text-sm text-gray-500 text-left">
          <p>
            © 2025 Copyright | Powered by{" "}
            <a href="#" className="text-green-600 hover:underline">FocusedStudio</a>
          </p>
          <a
            href="#"
            className="mt-3 md:mt-0 border border-green-600 px-4 py-1 rounded-full text-green-600 hover:bg-green-50 transition"
          >
            Back To Top
          </a>
        </div>
      </footer>
    );
}
export default Foter;