import Navbar from '../Navbar/navbar';
import Footer from '../Footer/footer';
import { JobCard } from './JobCard';
import { StatsHeader } from './StatsHeader';

function MyJobs() {
  const jobExample = {
    title: "YouTube Thumbnail Design (Trial Project)",
    description:
      "I'm looking for a YouTube thumbnail design for a single upcoming video on my channel.",
    tags: ["Youtube", "Design", "Thumbnails"],
    salary: "$20K-$50K",
    deadline: "06 April, 2023",
    price: 29,
    onClick: () => alert("You clicked 'See More'"),
  };

  const stats = {
    earnings: 29,
    withdrawals: 29,
    totalJobs: 29,
    balance: 29,
  };

  return (
    <div>
      <Navbar />
      <div className="px-4 md:px-20 py-6">
        {/* Kategoritë sipër */}
        <div className="text-center text-sm text-gray-700 mb-4">
          Development & IT | AI Services | Design & Creative | Sales & Marketing | Admin & Customer Support
        </div>

        {/* Titulli kryesor */}
        <h1 className=" font-bold text-center py-6 text-[66px]">
          My <span className="text-[#216F4C]">jobs.</span>
        </h1>
        <hr className="" />

        {/* Statistikat */}
        <StatsHeader
          earnings={stats.earnings}
          withdrawals={stats.withdrawals}
          totalJobs={stats.totalJobs}
          balance={stats.balance}
        />
        <hr />
        {/* Online Jobs */}
        <section className="mt-6">
          <h2 className="font-semibold text-gray-700 mb-2">Online Jobs</h2>
          <JobCard {...jobExample} />
        </section>

        {/* Recent Jobs */}
        <section className="mt-8">
          <h2 className="font-semibold text-gray-700 mb-2">Recent Jobs</h2>
          <JobCard {...jobExample} />
        </section>
      </div>

      <Footer />
    </div>
  );
}

export default MyJobs;
