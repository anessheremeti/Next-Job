import React, { useState } from 'react';
import UserCard from '../UserCard/UserCard';
import dummyUsers from '../DummyUsers/DummyUsers';

const UsersList = ({ users, selectedUserId, setSelectedUserId }) => {
  return (
    <div className="grid items-start gap-4 p-6 mt-2 bg-gray-50 min-h-full bg-lightBackground">
      {users.map((user) => (
        <UserCard
          key={user.id}
          imgUrl={user.imgUrl}
          name={user.name}
          message={user.message}
          date={user.date}
          id={user.id}
          isSelected={user.id === selectedUserId}
          onSelect={() => setSelectedUserId(user.id)}
        />
      ))}
    </div>
  );
};



export default UsersList;
