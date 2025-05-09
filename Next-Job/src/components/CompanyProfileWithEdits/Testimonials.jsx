import React from 'react';
import Arrayright from '../../assets/array-right.png';
const testimonials = [
  {
    name: "Kristin Watson",
    rating: 4.82,
    published: "2 months ago",
    text: "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don’t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn’t anything embarrassing hidden in the middle of text.",
    image: "https://randomuser.me/api/portraits/women/44.jpg"
  },
  {
    name: "Darrell Steward",
    rating: 4.82,
    published: "2 months ago",
    text: "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don’t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn’t anything embarrassing hidden in the middle of text.",
    image: "https://randomuser.me/api/portraits/men/45.jpg"
  }
];

const Testimonials = () => {
  return (
    <div className=" mx-auto py-10 px-4  flex flex-col">
      <h2 className="text-2xl font-semibold mb-6">What they employee says</h2>
      {testimonials.map((testimonial, index) => (
        <div key={index} className="mb-8 flex flex-col gap-4 items-start pb">
          <div className=' flex gap-4 '>
            <img
                src={testimonial.image}
                alt={testimonial.name}
                className="w-12 h-12 rounded-full object-cover"
            />
                <div className="flex flex-col items-start gap-2 text-sm font-medium justify-start">
                    <div>        
                            <span>{testimonial.name}</span>
                    </div>
                    <div className='flex gap-3'>
                        <span className="text-yellow-500">⭐ {testimonial.rating}</span>
                        <span className="text-gray-500">Published {testimonial.published}</span>
                    </div>
                </div>
          </div>
          <div className='pb-4'>
            <p className="mt-2 text-gray-600">{testimonial.text}</p>
          </div>
        </div>
      ))}
      <button className="c mt-7 px-6 py-2 bg-[#216F4C1A] text-[#216F4C] rounded-md font-semibold flex items-center gap-3 hover:bg-green-200 w-[220px] h-[48px] justify-center">
        See More <img src={Arrayright} className="text-[#216F4C]" alt="" />
      </button>
    </div>
  );
};

export default Testimonials;
