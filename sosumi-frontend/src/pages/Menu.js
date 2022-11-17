import React, { useState, useEffect } from 'react'
import ItemList from '../components/ItemList'

export default function Menu({user}) {
    const [items, setItems] = useState([]);
    const [favList, setFavList] = useState([]);
    const [favView, setFavView] = useState(false);
    const [currentUser, setCurrentUser] = useState({});

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
          });
      }, []);

      useEffect(() => {
        fetch(
          'https://localhost:7283/api/User/getUserByFireBaseId/' + user.$.W,
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
            setCurrentUser(r);
          });

        fetch(
          'https://localhost:7283/api/User/favorites/' + currentUser.id,
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
      },[favList])
  return (
    <div>
        <div>
            <h1>SoSuMi Main Menu :)</h1>
            <button onClick={() => handleChange()}>{favView ? "Go Back To Menu" : "View Favorites"}</button>
        </div>
        <ItemList items={favView ? favList : items} currentUser={currentUser}/>
    </div>
  )
}
