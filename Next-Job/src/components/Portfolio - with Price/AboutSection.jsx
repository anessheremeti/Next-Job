import React from 'react';
import Dislike from "../../assets/dislike.png";
import Like from "../../assets/like.png";
import Arrow from "../../assets/arrow.png";

const AboutSection = () => {
  return (
    <div className="w-[87%]  m-auto px-4 py-20 ">
      <h2 className="text-2xl font-semibold mb-4">About</h2>
      <p className="text-gray-700 mb-6">
        It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout...
      </p>

      <h3 className="text-xl font-medium mb-2">Services I provide:</h3>
      <ul className=" flex flex-col gap-3 list-decimal list-inside text-gray-800 mb-6 space-y-1">
        <li>Website Design</li>
        <li>Mobile App Design</li>
        <li>Brochure Design</li>
        <li>Business Card Design</li>
        <li>Flyer Design</li>
      </ul>

      <p className="text-gray-600 mb-10">
        Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text...
      </p>

      <div className="grid grid-cols-1 sm:grid-cols-3 gap-6 mb-10 py-6">
        <div>
          <p className="font-semibold text-gray-700">App type</p>
          <p className="text-gray-600">Business, Food & drink, Graphics & design</p>
        </div>
        <div>
          <p className="font-semibold text-gray-700">Design tool</p>
          <p className="text-gray-600">Adobe XD, Figma, Adobe Photoshop</p>
        </div>
        <div>
          <p className="font-semibold text-gray-700">Device</p>
          <p className="text-gray-600">Mobile, Desktop</p>
        </div>
      </div>

      <hr className="my-6" />

      <div className="space-y-8">
        <ReviewCard
          name="Kristin Watson"
          rating={4.82}
          time="2 months ago"
          content="There are many variations of passages of Lorem Ipsum available,
           but the majority have suffered alteration There are many variations of passages of Lorem Ipsum available,
            but the majority have suffered alteration There are many variations of passages of Lorem Ipsum available,
             but the majority have suffered alteration"
        />
        <ReviewCard
          name="Darrell Steward"
          rating={4.82}
          time="2 months ago"
          content="There are many variations of passages of Lorem Ipsum available,
           but the majority have suffered alteration There are many variations of passages of Lorem Ipsum available,
            but the majority have suffered alteration There are many variations of passages of Lorem Ipsum available,
             but the majority have suffered alteration"
        />
      </div>

      <button className="my-10 bg-[#5BBB7B1A] text-[#5BBB7B] font-semibold px-6 py-2 rounded flex flex-row items-center gap-2 hover:bg-[#3c6f4d1a] transition">
        See More <img src={Arrow} alt="" />
      </button>
      <hr className='w-[100%]' />
    </div>
  );
};

const ReviewCard = ({ name, rating, time, content }) => (
  <div className='flex flex-col gap-6 pt-10'>
    <div className="flex flex-col justify-start gap-1 px-3">
      <p className="font-medium text-gray-800">{name}</p>
      <p className="text-sm text-gray-600">
        ⭐ {rating} • Published {time}
      </p>
    </div>
    <p className="text-gray-700 mt-2">{content}</p>
    <div className="flex gap-4 text-sm text-gray-500 mt-2">
      <button className="flex justify-center items-center gap-1 hover:underline "><img className='w-[13.06px] h-[13.66px]' src={Like} alt="" /> Helpful</button>
      <button className="flex justify-center items-center gap-1  hover:underline"> <img className='w-[13.06px] h-[13.66px]' src={Dislike} alt="" /> Not Helpful</button>
    </div>
  </div>
);

export default AboutSection;
