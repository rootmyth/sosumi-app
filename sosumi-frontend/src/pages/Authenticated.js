import { React, useEffect, useState } from 'react';
import { signOut } from '../utils/auth';

export default function Authenticated({ user }) {
  const [items, setItems] = useState([]);
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
  }, []);
  return (
    <div className="text-center mt-5">
      <h1>Welcome, {user.displayName}!</h1>
      <img
        referrerPolicy="no-referrer"
        src={user.photoURL}
        alt={user.displayName}
      />
      <div className="mt-2">
        <button type="button" className="btn btn-danger" onClick={signOut}>
          Sign Out
        </button>
      </div>
      <div>
        <h1>item list below</h1>
        <h2>{items.map((x) => x.name)}</h2>
      </div>
    </div>
  );
}
