

function Tablewithdrawal(){

    return(
        <div className="overflow-x-auto p-6 mx-16 ">
          <div className="get-paid flex justify-between items-center mb-5">
            <div className="balance flex flex-col gap-2">
            <h1 className="text-4xl font-monument mb-6">Get <span className="text-[#216F4C]">Paid</span></h1>

                <p className="font-medium font-sans">Balance</p>
                <h3 className="text-2xl font-bold text-[#216F4C]">$291.00</h3>
                <h3 className="text-xl mt-4 font-monument text-[#202224]">Withdrawal Requests</h3>

            </div>
            <button className="border bg-[#216F4C] hover:bg-transparent hover:text-[#216F4C] hover:border hover:border-[#216F4C] px-5 py-2 rounded-full text-[#ffffff] font-poppins font-semibold">New Withdrawal</button>
            
          </div>
        <table className="min-w-full shadow-sm rounded-md">
          <thead className="bg-gray-white  ">
            <tr className=" text-[#202225]">
              <th className="px-4 py-6 text-left font-extrabold text-sm text-gray-700 border-b border-gray-300">ID</th>
              <th className="px-4 py-6 text-left font-extrabold text-sm text-gray-700 border-b border-gray-300">Full Name</th>
              <th className="px-4 py-6 text-left font-extrabold text-sm text-gray-700 border-b border-gray-300">Email</th>
              <th className="px-4 py-6 text-left font-extrabold text-sm text-gray-700 border-b border-gray-300">Amount</th>
              <th className="px-4 py-6 text-left font-extrabold text-sm text-gray-700 border-b border-gray-300">Gateway</th>
              <th className="px-4 py-6 text-left font-extrabold text-sm text-gray-700 border-b border-gray-300">Created</th>
              <th className="px-4 py-6 text-left font-extrabold text-sm text-gray-700 border-b border-gray-300">Status</th>
            </tr>
          </thead>
          <tbody className="bg-white">
            <tr className="hover:bg-gray-50 font-semibold text-[#202224]">
              <td className="px-4 py-6 text-left border-b border-gray-300">001</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">Focused </td>
              <td className="px-4 py-6 text-left border-b border-gray-300">ajeti182@gmail.com</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">$252</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">Crypto</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">01/10/2024</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">
                <span className="text-green-600 font-medium">Paid</span>
              </td>
            </tr>
      
            <tr className="hover:bg-gray-50 font-semibold text-[#202224]">
              <td className="px-4 py-6 text-left border-b border-gray-300">002</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">Focused </td>
              <td className="px-4 py-6 text-left border-b border-gray-300">ajeti182@gmail.com</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">$252</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">Crypto</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">01/10/2024</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">
                <span className="text-yellow-500 font-medium">Pending</span>
              </td>
            </tr>
      
            <tr className="hover:bg-gray-50 font-semibold text-[#202224]">
              <td className="px-4 py-6 text-left border-b border-gray-300">003</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">Focused </td>
              <td className="px-4 py-6 text-left border-b border-gray-300">ajeti182@gmail.com</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">$252</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">Crypto</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">01/10/2024</td>
              <td className="px-4 py-6 text-left border-b border-gray-300">
                <span className="text-red-500 font-medium">Declined</span>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      
      
    );
}
export default Tablewithdrawal;

