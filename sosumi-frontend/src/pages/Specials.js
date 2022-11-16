import React, { useState, useEffect } from 'react'
import ItemList from '../components/ItemList'

export default function Specials() {
    const [items, setItems] = useState([]);

    useEffect(() => {
        fetch(
          'https://localhost:7283/api/Item/Special',
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
            setItems(r);
            //console.table(r);
          });
      }, []);

  return (
    <div>
        <div>
            <h1>SoSuMi Specials :)</h1>
        </div>
        <ItemList items={items}/>
    </div>
  )
}
