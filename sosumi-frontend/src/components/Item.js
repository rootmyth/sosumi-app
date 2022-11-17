import React, { useState, useEffect } from 'react'
import { FaStar } from 'react-icons/fa';
import '../styles/item.css'

export default function Item({item, currentUser}) {
    const {name, price, id} = item;

    const [fav, setFav] = useState();
    useEffect(() => {
      fetch(
        "https://localhost:7283/api/Item/" + currentUser.id + "/" + id,
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
          'https://localhost:7283/api/Favorite/addFavorite/' + currentUser.id + '/'+item.id,
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
          'https://localhost:7283/api/Favorite/deleteFavorite/' + currentUser.id + '/' +item.id,
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
