
function ProfileCard({ coverImage, profileImage, name, location, title, description, experience }) {
  return (
    <div className=" mx-auto mt-4  rounded-xl ">
      {/* Cover Image */}
      <div className="relative h-48 ">
        <img
          src={coverImage}
          alt="Cover"
          className="w-full h-full object-cover rounded-xl"
        />
        <div className="absolute bottom-[-40px] left-1/2 transform -translate-x-1/2">
          <img
            src={profileImage}
            alt="Profile"
            className="w-20 h-20 rounded-full border-4 border-white bg-white"
          />
        </div>
      </div>

      {/* Profile Details */}
      <div className="pt-16 px-6 pb-6 text-center">
        <h2 className="text-2xl font-semibold">{name}</h2>
        <div className="text-sm text-gray-500 flex justify-center items-center gap-1">
         {location}
        </div>

        <div className="mt-4 text-lg font-semibold flex items-center justify-center gap-1">
          {title} 
        </div>

        <p className="mt-2 text-sm text-gray-600">
          {description}
        </p>

        <p className="mt-4 text-sm text-gray-600 flex items-center justify-center gap-1">
          {experience} 
        </p>
      </div>
    </div>
  );
}

export default ProfileCard;
