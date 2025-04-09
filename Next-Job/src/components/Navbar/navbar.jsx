import React from 'react'

function navbar() {
  return (
    <nav>
        <img src="/Next-Job/src/assets/Logo 1.png" alt="logo" />
        <ul>
            <li><a href="#">Find Talent</a></li>
            <li><a href="#">Companies</a></li>
            <li><a href="#">Find Work</a></li>
        </ul>
        <div className="nav-buttons">
            <button>Log in</button>
            <button>Register</button>
        </div>
    </nav>
  )
}

export default navbar