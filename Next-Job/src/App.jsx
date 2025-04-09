import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Withdrawal from "../src/withdrawal/Withdrawal.jsx";

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <h1 className="text-6xl text-red-500">Hello</h1>
      <Withdrawal></Withdrawal>
    </>
  );
}

export default App;
