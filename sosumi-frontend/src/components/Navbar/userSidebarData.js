import React from "react"
import {AiOutlineProfile} from "react-icons/ai"
import {FiMapPin} from "react-icons/fi"
import {SlLogout} from "react-icons/sl"

export const userSidebarData = [
    {
      title: 'Profile',
      path: './profile',
      icon: <AiOutlineProfile />,
      className: 'nav-text'
    },
    {
      title: 'Address',
      path: './address',
      icon: <FiMapPin />,
      className: 'nav-text'
    },
    {
      title: 'Logout',
      path: './',
      icon: <SlLogout />,
      className: 'nav-text'
    }
  ]