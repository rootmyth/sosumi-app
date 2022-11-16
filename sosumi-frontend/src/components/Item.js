import React, { useState, useEffect } from 'react'
import { FaStar } from 'react-icons/fa';
import '../styles/item.css'

export default function Item({item}) {
    const {name, price, id} = item;

    const [fav, setFav] = useState();
    useEffect(() => {
      fetch(
        "https://localhost:7283/api/Item/1/" + id,
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
          setFav(r);
        });
    }, [])

    const handleAdd = () => {
        fetch(
          'https://localhost:7283/api/Favorite/addFavorite/1/'+item.id,
          {
            method: 'POST',
            headers: {
              'Access-Control-Allow-Origin': 'https://localhost:7283',
              'Content-Type': 'application/json',
            },
            body:""
          },
        )
        setFav(!fav);
    }

    const handleDelete = () => {
              fetch(
          'https://localhost:7283/api/Favorite/deleteFavorite/1/'+item.id,
          {
            method: 'DELETE',
            headers: {
              'Access-Control-Allow-Origin': 'https://localhost:7283',
              'Content-Type': 'application/json',
            },
          },
        )
      setFav(!fav);
    }
    

  return (
    <>
    <div>
        Name: {name}  Price: {price} 
        {fav ? <button onClick={() => handleDelete()}><FaStar className="isFav"/></button> : <button onClick={() => handleAdd()}><FaStar className="isNotFav"/></button>}
        
    </div>
    </>
  )
}
