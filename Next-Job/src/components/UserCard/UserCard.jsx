import React from 'react';

const UserCard = ({ imgUrl, name, message, date, id, isSelected, onSelect }) => {
  return (
    <div
      onClick={onSelect}
      className={`flex justify-between items-start p-4 rounded-2xl shadow-md w-full max-w-md cursor-pointer transition-colors duration-200 
        ${isSelected ? 'bg-deepGreen text-white' : 'bg-white'}`}
    >
      <div className="flex gap-4 items-start">
        <img
          src={imgUrl}
          alt={`${name}'s avatar`}
          className="w-12 h-12 rounded-full object-cover"
        />
        <div className="flex flex-col">
          <span className={`font-semibold ${isSelected ? 'text-white' : 'text-gray-900'}`}>{name}</span>
          <span className={`text-sm ${isSelected ? 'text-white' : 'text-gray-600'}`}>{message}</span>
        </div>
      </div>
      <p className={`text-xs ${isSelected ? 'text-white' : 'text-gray-500'}`}>{date}</p>
    </div>
  );
};

export default UserCard;
