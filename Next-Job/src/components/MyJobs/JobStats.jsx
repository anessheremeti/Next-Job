export function JobStats({ earnings, withdrawals, totalJobs, balance }) {
    return (
      <div className="grid grid-cols-2 md:grid-cols-4 gap-4 text-center py-6">
        <StatBox label="Total Earnings" value={earnings} />
        <StatBox label="Total Withdrawals" value={withdrawals} />
        <StatBox label="Total Jobs" value={totalJobs} />
        <StatBox label="Balance" value={balance} />
      </div>
    );
  }
  
  function StatBox({ label, value }) {
    return (
      <div>
        <p className="text-sm text-[#222222]">{label}</p>
        <p className="text-lg font-semibold text-[#216F4C]">${value}</p>
      </div>
    );
  }
  