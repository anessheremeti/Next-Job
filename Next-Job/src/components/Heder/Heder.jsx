import { useState } from "react";

export default function Header() {
  const [hovered, setHovered] = useState(null); // 'talent', 'companies', 'work'
  const [authHovered, setAuthHovered] = useState(null); // 'login' | 'register' | null

  return (
    <header className="bg-white mb-5">
      <div className=" mx-2 px-4 py-4 flex items-center justify-between">
        {/* Logo */}
        <div className="flex items-center space-x-2">
          <img src="/logo.png" alt="NextJob Logo" className="w-6 h-6" />
          <span className="text-2xl font-bold">
            <span className="text-black">Next</span>
            <span className="text-green-600">Job</span>
          </span>
        </div>

        {/* Navigation */}
        <nav className="hidden md:flex items-center border border-gray-300 rounded-full overflow-hidden text-sm">
          <a
            href="#"
            onMouseEnter={() => setHovered("talent")}
            onMouseLeave={() => setHovered(null)}
            className={`px-4 py-2 transition-all duration-200 rounded-3xl	${
              hovered === null || hovered === "talent"
                ? "text-green-700 bg-green-100 font-medium"
                : "text-gray-700"
            }`}
          >
            • Find Talent
          </a>

          <a
            href="#"
            onMouseEnter={() => setHovered("companies")}
            onMouseLeave={() => setHovered(null)}
            className={`px-4 py-2 transition-all duration-200 rounded-3xl	 ${
              hovered === "companies"
                ? "text-green-700 bg-green-100 font-medium"
                : "text-gray-700"
            }`}
          >
            • Companies
          </a>

          <a
            href="#"
            onMouseEnter={() => setHovered("work")}
            onMouseLeave={() => setHovered(null)}
            className={`px-4 py-2 transition-all duration-200 rounded-3xl	 ${
              hovered === "work"
                ? "text-green-700 bg-green-100 font-medium"
                : "text-gray-700"
            }`}
          >
            • Find Work
          </a>
        </nav>

        {/* Auth Buttons */}
        <div className="flex items-center space-x-2">
          {/* Log In */}
          <a
            href="#"
            onMouseEnter={() => setAuthHovered("login")}
            onMouseLeave={() => setAuthHovered(null)}
            className={`px-4 py-1 rounded-full border transition-all duration-200 ${
              authHovered === "login"
                ? "bg-green-800 text-white border-green-800"
                : authHovered === "register"
                ? "bg-green-50 text-green-700 border-green-600"
                : "border-green-600 text-green-600 hover:bg-green-50"
            }`}
          >
            Log In
          </a>

          {/* Register */}
          <a
            href="#"
            onMouseEnter={() => setAuthHovered("register")}
            onMouseLeave={() => setAuthHovered(null)}
            className={`px-4 py-1 rounded-full transition-all duration-200 ${
              authHovered === "register"
                ? "bg-green-800 text-white"
                : authHovered === "login"
                ? "bg-green-50 text-green-700 border border-green-600"
                : "bg-green-700 text-white hover:bg-green-800"
            }`}
          >
            Register
          </a>
        </div>
      </div>
    </header>
  );
}
