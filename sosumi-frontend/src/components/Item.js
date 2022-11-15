import React, { useState, useEffect } from 'react'
import '../styles/item.css'

export default function Item({item, favorited}) {
    const {name, price} = item;
    const [fav, setFav] = useState(favorited);
    
    const handleOnClick = () => {
      if(fav){
        fetch(
          'https://localhost:7283/api/Favorite/deleteFavorite/7/'+item.id,
          {
            method: 'DELETE',
            headers: {
              'Access-Control-Allow-Origin': 'https://localhost:7283',
              'Content-Type': 'application/json',
            },
          },
        )
      } else {
        fetch(
          'https://localhost:7283/api/Favorite/addFavorite/7/'+item.id,
          {
            method: 'POST',
            headers: {
              'Access-Control-Allow-Origin': 'https://localhost:7283',
              'Content-Type': 'application/json',
            },
            body:""
          },
        )
      }
      setFav(!fav);
    }

  return (
    <>
    <div>
        Name: {name}  Price: {price} 
        <button onClick={handleOnClick} className={favorited? "favorite" : "not favorite"}>{fav ? "Delete from favorite" : "add to favorite"}</button>
    </div>
    </>
  )
}
