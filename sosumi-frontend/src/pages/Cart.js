import React, { useEffect, useState } from 'react'
import ItemList from '../components/ItemList';

export default function Cart() {
    const [cart, setCart] = useState([]);

    useEffect(() => {
        fetch(
          'https://localhost:7283/api/Order/user/1/cart',
          {
            method: 'GET',
            headers: {
              'Access-Control-Allow-Origin': 'https://localhost:7283',
              'Content-Type': 'application/json',
            },
          },
        )
          .then((res) => res.json())
          .then((r) => {
            setCart(r);
          });
      }, []);

  return (

    <div>
        <h1>DIS IS UR CART</h1>
        {cart.length > 0 ? <ItemList items={cart} /> : <div>No Items In your cart</div>}
    </div>
  )
}
