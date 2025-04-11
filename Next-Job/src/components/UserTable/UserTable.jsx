import React from 'react';

const UserTable = ({ columns, data }) => {
  return (
    <div className="overflow-x-auto w-full">
      <table className="min-w-full bg-white  border-gray-200 rounded-xl text-sm text-left text-gray-700">
        <thead className="text-black">
          <tr>
            {columns.map((column, index) => (
              <th key={index} className="px-4 py-3 font-semibold text-black whitespace-nowrap">
                {column.header}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {data.map((row, rowIdx) => (
            <tr key={rowIdx} className=" border-b-2 transition">
              {columns.map((column, colIdx) => {
                const value = column.accessorKey ? row[column.accessorKey] : null;
                return (
                  <td key={colIdx} className="px-4 py-3 whitespace-nowrap text-black">
                    {column.cell ? column.cell({ row }) : value}
                  </td>
                );
              })}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default UserTable;
