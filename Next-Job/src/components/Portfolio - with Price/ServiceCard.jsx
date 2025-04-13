export default function ServiceCard({
  image,
  category,
  title,
  rating,
  reviews,
  name,
  price,
}) {
  return (
    <div className="w-[318px] rounded-2xl space-y-4">
      <img
        src={image}
        alt="Service Preview"
        className="rounded-xl w-full object-cover"
      />
      <div className="text-sm text-gray-500">{category}</div>
      <div className="text-lg font-semibold text-gray-800">{title}</div>
      <div className="flex items-center text-sm text-yellow-500 space-x-1">
        <span>⭐</span>
        <span>{rating}</span>
        <span className="text-gray-400">({reviews} reviews)</span>
      </div>
      <div className="flex items-center justify-between">
        <div className="text-sm text-gray-700 font-medium">{name}</div>
        <div className="text-sm font-semibold text-gray-900">
          Starting at <span className="text-green-600">${price}</span>
        </div>
      </div>
    </div>
  );
}