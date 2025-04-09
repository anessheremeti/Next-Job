

function Tablewithdrawal(){

    return(
        <div className="overflow-x-auto p-6 mx-16 ">
        <table className="min-w-full shadow-sm rounded-md">
          <thead className="bg-gray-white hover:bg-gray-50">
            <tr>
              <th className="px-4 py-3 text-left font-semibold text-sm text-gray-700 border-b border-gray-300">ID</th>
              <th className="px-4 py-3 text-left font-semibold text-sm text-gray-700 border-b border-gray-300">Full Name</th>
              <th className="px-4 py-3 text-left font-semibold text-sm text-gray-700 border-b border-gray-300">Email</th>
              <th className="px-4 py-3 text-left font-semibold text-sm text-gray-700 border-b border-gray-300">Amount</th>
              <th className="px-4 py-3 text-left font-semibold text-sm text-gray-700 border-b border-gray-300">Gateway</th>
              <th className="px-4 py-3 text-left font-semibold text-sm text-gray-700 border-b border-gray-300">Created</th>
              <th className="px-4 py-3 text-left font-semibold text-sm text-gray-700 border-b border-gray-300">Status</th>
            </tr>
          </thead>
          <tbody className="bg-white">
            <tr className="hover:bg-gray-50">
              <td className="px-4 py-3 text-left border-b border-gray-300">001Focused</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">Focused Ajeti</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">ajeti182@gmail.com</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">$252</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">Crypto</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">01/10/2024</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">
                <span className="text-green-600 font-medium">Paid</span>
              </td>
            </tr>
      
            <tr className="hover:bg-gray-50">
              <td className="px-4 py-3 text-left border-b border-gray-300">002Focused</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">Focused Ajeti</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">ajeti182@gmail.com</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">$252</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">Crypto</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">01/10/2024</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">
                <span className="text-yellow-500 font-medium">Pending</span>
              </td>
            </tr>
      
            <tr className="hover:bg-gray-50">
              <td className="px-4 py-3 text-left border-b border-gray-300">003Focused</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">Focused Ajeti</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">ajeti182@gmail.com</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">$252</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">Crypto</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">01/10/2024</td>
              <td className="px-4 py-3 text-left border-b border-gray-300">
                <span className="text-red-500 font-medium">Declined</span>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      
      
    );
}
export default Tablewithdrawal;

