import React from 'react'
import {AiOutlineStar, AiOutlineHeart, AiOutlineHistory, AiOutlineShoppingCart} from "react-icons/ai"
import {MdMenuBook} from "react-icons/md"

export const SidebarMenuData = [
  {
    title: 'Menu',
    path: './',
    icon: <MdMenuBook />,
    className: 'nav-text'
  },
  {
    title: 'Cart',
    path: './cart',
    icon: <AiOutlineShoppingCart />,
    className: 'nav-text'
  },
  {
    title: 'Specials',
    path: './speicals',
    icon: <AiOutlineStar />,
    className: 'nav-text'
  },
  {
    title: 'Order History',
    path: './order_history',
    icon: <AiOutlineHistory />,
    className: 'nav-text'
  },
  {
    title: 'Popular',
    path: './popular',
    icon: <AiOutlineHeart />,
    className: 'nav-text'
  }
]