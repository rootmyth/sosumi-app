import React from 'react'
import  Item  from './Item'

export default function ItemList({items, currentUser}) {



  return (
    <div>
        {items.map(item => <Item key={item.id} item={item} currentUser={currentUser}/>)}
    </div>
  )
}
