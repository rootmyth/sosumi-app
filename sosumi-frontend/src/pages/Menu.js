import React, { useState, useEffect } from 'react'
import ItemList from '../components/ItemList'

export default function Menu() {
    const [items, setItems] = useState([]);
    const [favList, setFavList] = useState([]);
    const [favView, setFavView] = useState(false);

    const handleChange = () => {
       setFavView(!favView)
    }

    useEffect(() => {
        fetch(
          'https://localhost:7283/api/Item',
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
            console.table(r);
          });

          if(!favView){
            fetch(
              'https://localhost:7283/api/User/favorites/1',
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
                setFavList(r);
              });
          }
      }, []);
      console.log("favlist coming")
      console.log(favList)
  return (
    <div>
        <div>
            <h1>SoSuMi Main Menu :)</h1>
            <button onClick={handleChange}>View Favorites</button>
        </div>
        <ItemList items={favView ? favList : items} favList={favList}/>
    </div>
  )
}
