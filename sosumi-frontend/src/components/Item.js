import React from 'react'

export default function Item({item}) {
    const {name, price} = item;
  return (
    <>
    <div>
        Name: {name}  Price: {price} 
    </div>
    </>
  )
}
