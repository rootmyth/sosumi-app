import React, {useState} from "react"
import "./Navbar.css"
import {FaBars, FaTimes } from "react-icons/fa";
import { Link } from "react-router-dom";
import { SidebarMenuData } from "./SidebarMenuData";
import { IconContext } from 'react-icons'

const Navbar = () => {
   const [sidebar, setSidebar] = useState(false)

   const showSidebar = () => setSidebar(!sidebar)

    return (
        <>
        <IconContext.Provider value={{color: '#fff'}}>
      <nav className="navbar">
        <Link to="#" className='menu-bars'>
            <FaBars onClick={showSidebar}/>
        </Link>
        <h2>SoSumi</h2>
        <nav className={sidebar ? 'nav-menu active' : 'nav-menu'}>
            <ul className="nav-menu-items" onClick={showSidebar}>
                <li className="navbar-toggle">
                    <Link to="/#" className="menu-bars">
                        <FaTimes />
                    </Link>
                </li>
                {SidebarMenuData.map((item, index) => {
                    return (
                        <li key={index} className={item.className}>
                            <Link to={item.path}>
                                {item.icon}
                                <span>{item.title}</span>
                            </Link>
                        </li>
                    )
                })}
            </ul>
        </nav>
     
      </nav>
      </IconContext.Provider>
      </>
    );
};

export default Navbar