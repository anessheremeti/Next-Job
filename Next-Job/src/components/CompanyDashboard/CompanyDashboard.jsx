import logo from '../../assets/Logo 1.png';
import Aside from '../Aside/Aside';
import UserTable from '../UserTable/UserTable';
import bin from '../../assets/bin.png';


const CompanyDashboard = () => {
  const data = [
    {
      id: '001',
      company: 'Focused',
      owner:'Engjell Ajeti',
      email: 'ajeti182@gmail.com',
      listed: '$252',
      category: 'AI Company',
      created: '01/10/2024',
    },
    {
        id: '002',
        company: 'Focused',
        owner:'Engjell Ajeti',
        email: 'ajeti182@gmail.com',
        listed: '$252',
        category: 'AI Company',
        created: '01/10/2024',
      }, {
        id: '003',
        company: 'Focused',
        owner:'Engjell Ajeti',
        email: 'ajeti182@gmail.com',
        listed: '$252',
        category: 'AI Company',
        created: '01/10/2024',
      },
  ];

  const renderActions = (row) => {
    if (row.id === '001') {
      return (
        <div className="flex  items-center">
          <img src={bin} alt="Delete" className="w-4 h-4 cursor-pointer" />
         
        </div>
      );
    }
    if (row.id === '002') {
      return (
        <div className="flex gap-3 items-center">
          <img src={bin} alt="Delete" className="w-4 h-4 cursor-pointer" />
         
        </div>
    
      ) }
      
    if (row.id === '003') {
      return (
        <div className="flex items-center">
          <img src={bin} alt="Delete" className="w-4 h-4 cursor-pointer" />
       
        </div>
    
      ) }
    return null;
  };

  const columns = [
    { header: 'ID', accessorKey: 'id' },
    { header: 'Company', accessorKey: 'company' },
    { header: 'Owner', accessorKey: 'owner' },
    { header: 'Email', accessorKey: 'email' },
    { header: 'Listed', accessorKey: 'listed' },
    { header: 'Category', accessorKey: 'category' },
    { header: 'Created', accessorKey: 'created' },
    {
      header: 'Actions',
      accessorKey: 'actions',
      cell: ({ row }) => renderActions(row),
    },
  ];

  return (
    <div className="container mx-auto px-3">
      <header className="flex flex-col sm:flex-row items-center justify-between py-5">
        <img className="w-32 sm:w-36 object-contain" src={logo} alt="Logo" />
      </header>
      <div className="flex flex-col md:flex-row">
        <aside className=" mb-4 md:mb-0">
          <Aside />
        </aside>
        <main className=" w-full">
          <p className="font-clashDisplay text-black text-lg font-bold mb-4">
            Companies
          </p>
          <UserTable columns={columns} data={data} />
        </main>
      </div>
    </div>
  );
};

export default CompanyDashboard;
