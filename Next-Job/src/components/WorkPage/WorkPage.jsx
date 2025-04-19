import Navbar from '../Navbar/navbar'
import Footer from '../Footer/footer'
import JobPost from './JobPost';
import ClientInfoCard from './ClientInfoCard';
import Arrayright from "../../assets/array-right.png";

function WorkPage() {
    return (
        <div className="">
            <Navbar />
            <div className="items-center px-20">
                <div className="text-center text-sm text-gray-700 mb-4 pb-4">
                    Development & IT | AI Services | Design & Creative | Sales & Marketing | Admin & Customer Support
                </div>
                <JobPost />

                {/* Wrapper div for About and ClientInfoCard side by side */}
                <div className="flex flex-row flex-wrap gap-14 pt-10">

                    {/* About Section */}
                    <div className="flex-1 min-w-[300px]">
                        <h2 className="text-2xl font-semibold mb-4">About this project</h2>
                        <p className="text-gray-700 mb-6">
                            It is a long established fact that a reader will be distracted by the readable content...
                        </p>

                        <h3 className="text-xl font-medium mb-2">Services I provide:</h3>
                        <ul className="flex flex-col gap-3 list-decimal list-inside text-gray-800 mb-6">
                            <li>Website Design</li>
                            <li>Mobile App Design</li>
                            <li>Brochure Design</li>
                            <li>Business Card Design</li>
                            <li>Flyer Design</li>
                        </ul>

                        <p className="text-gray-600 mb-10">
                            Many desktop publishing packages and web page editors now use Lorem Ipsum...
                        </p>

                        <div className="flex flex-row gap-14 flex-wrap py-7 pb-14">
                            <div className="max-w-[150px]">
                                <p className="font-semibold text-gray-700">App type</p>
                                <p className="text-gray-600">Business, Food & drink, Graphics & design</p>
                            </div>
                            <div className="max-w-[150px]">
                                <p className="font-semibold text-gray-700">Design tool</p>
                                <p className="text-gray-600">Adobe XD, Figma, Adobe Photoshop</p>
                            </div>
                            <div className="max-w-[150px]">
                                <p className="font-semibold text-gray-700">Device</p>
                                <p className="text-gray-600">Mobile, Desktop</p>
                            </div>
                        </div>
                    </div>

                    {/* Client Info Card */}
                    <div className="w-full sm:w-[300px]">
                        <ClientInfoCard
                            location="London, UK"
                            memberSince="April 2022"
                            lastProject="5 days"
                            gender="Male"
                            languages="English"
                            country="Belgium"
                            onContact="+383 49 666 999"
                        />
                    </div>
                </div>
                <hr />
                <div className="flex flex-col  justify-between items-start gap-5  border-b  space-y-3  py-9  ">
                        {/* Left side: Title & time */}
                        <div className="flex flex-col items-start justify-start gap-3">
                          <h2 className="text-lg font-semibold text-gray-900  ">
                          Skills and Expertise 
                          </h2>
                        </div>
                  
                        {/* Right side: Tags, Button & Link */}
                        <div className="flex flex-col md:items-end space-y-2 gap-3">
                          {/* Tags and button */}
                          <div className="flex flex-wrap items-center  justify-end gap-2">
                            <span className="bg-gray-100 text-gray-700 text-xs font-medium px-4 py-2 rounded-full">YouTube</span>
                            <span className="bg-gray-100 text-gray-700 text-xs font-medium px-4 py-2 rounded-full">Design</span>
                            <span className="bg-gray-100 text-gray-700 text-xs font-medium px-4 py-2 rounded-full">Thumbnails</span>
                            <div className="pl-5">
                          
                            </div>
                          </div>
                        </div>
                      </div>
            </div>
            

            <Footer />
        </div>
    );
}

export default WorkPage;
