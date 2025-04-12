export function StatsHeader({ earnings, withdrawals, totalJobs, balance }) {
    const stats = [
      { label: "Total Earnings", value: earnings },
      { label: "Total Withdrawals", value: withdrawals },
      { label: "Total Jobs", value: totalJobs },
      { label: "Balance", value: balance },
    ];
  
    return (
      <div className="flex flex-row justify-evenly flex-wrap  text-center py-6 gap-4">
        {stats.map((item, idx) => (
          <div className="w-[180px] " key={idx}>
            <p className="text-sm text-gray-500">{item.label}</p>
            <p className="text-lg font-semibold text-emerald-600">${item.value}</p>
          </div>
        ))}
      </div>
    );
  }
  