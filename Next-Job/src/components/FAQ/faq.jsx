import React from 'react';
import "./faq.css"


function Faq() {
  return (
    <div className="max-w-3xl mx-auto   rounded-2xl ">
      <div className="invisible absolute w-0 h-0">
        <svg xmlns="http://www.w3.org/2000/svg">
          <symbol viewBox="0 0 24 24" id="expand-more">
            <path d="M16.59 8.59L12 13.17 7.41 8.59 6 10l6 6 6-6z" />
            <path d="M0 0h24v24H0z" fill="none" />
          </symbol>
          <symbol viewBox="0 0 24 24" id="close">
            <path d="M19 6.41L17.59 5 12 10.59 6.41 5 5 6.41 10.59 12 5 17.59 6.41 19 12 13.41 17.59 19 19 17.59 13.41 12z" />
            <path d="M0 0h24v24H0z" fill="none" />
          </symbol>
        </svg>
      </div>

      {/** Each question block */}
      <details open className="border-b pb-4 border-[#B7FFDF]">
        <summary className="flex items-center justify-between cursor-pointer text-lg  text-gray-800 font-poppins open:text-[#216F4C]">
        Do these Servers have root/admin premissions?
          <div className="flex space-x-2">
            <svg className="w-6 h-6" role="presentation">
              <use xlinkHref="#expand-more" />
            </svg>
            <svg className="w-6 h-6 hidden" role="presentation">
              <use xlinkHref="#close" />
            </svg>
          </div>
        </summary>
        <p className="mt-2 text-gray-600 font-poppins">Our RDP servers offer dedicated environments with full administrative permissions. This means you have unrestricted access and control over your server, allowing you to install software, manage configurations, and tailor the environment to suit your needs.</p>
      </details>

      <details className="border-b pb-4 font-poppins border-[#B7FFDF]">
        <summary className="flex items-center justify-between cursor-pointer text-lg  text-gray-800">
          Can the AI handle multiple calls or messages at the same time?
          <div className="flex space-x-2">
            <svg className="w-6 h-6" role="presentation">
              <use xlinkHref="#expand-more" />
            </svg>
            <svg className="w-6 h-6 hidden" role="presentation">
              <use xlinkHref="#close" />
            </svg>
          </div>
        </summary>
        <p className="mt-2 text-gray-600">Yes! Unlike human receptionists, our AI can handle unlimited calls and messages simultaneously, ensuring no missed opportunities.</p>
      </details>

      <details className="border-b pb-4 font-poppins border-[#B7FFDF]">
        <summary className="flex items-center justify-between cursor-pointer text-lg  text-gray-800">
          Will customers know they are talking to AI?
          <div className="flex space-x-2">
            <svg className="w-6 h-6" role="presentation">
              <use xlinkHref="#expand-more" />
            </svg>
            <svg className="w-6 h-6 hidden" role="presentation">
              <use xlinkHref="#close" />
            </svg>
          </div>
        </summary>
        <p className="mt-2 text-gray-600">No, Nexlifa’s AI sounds completely human and engages in natural, lifelike conversations. Most callers won’t realize they are speaking with AI unless informed.</p>
      </details>

      <details className="border-b pb-4 font-poppins border-[#B7FFDF]">
        <summary className="flex items-center justify-between cursor-pointer text-lg  text-gray-800">
          What is the delivery time for RDP server & account details after payment?
          <div className="flex space-x-2">
            <svg className="w-6 h-6" role="presentation">
              <use xlinkHref="#expand-more" />
            </svg>
            <svg className="w-6 h-6 hidden" role="presentation">
              <use xlinkHref="#close" />
            </svg>
          </div>
        </summary>
        <p className="mt-2 text-gray-600">Only your imagination my friend. Go forth!</p>
      </details>

      <details className="border-b pb-4 font-poppins border-[#B7FFDF]">
        <summary className="flex items-center justify-between cursor-pointer text-lg  text-gray-800">
          How long does it take to set up Nexlifa for my business?
          <div className="flex space-x-2">
            <svg className="w-6 h-6" role="presentation">
              <use xlinkHref="#expand-more" />
            </svg>
            <svg className="w-6 h-6 hidden" role="presentation">
              <use xlinkHref="#close" />
            </svg>
          </div>
        </summary>
        <p className="mt-2 text-gray-600">Setup takes just a few days. We customize your AI agent to match your business needs, integrate it with your booking system, and ensure it’s ready to handle calls and messages smoothly.</p>
      </details>
    </div>
  );
}

export default Faq;
