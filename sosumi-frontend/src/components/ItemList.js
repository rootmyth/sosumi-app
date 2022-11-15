import React from 'react'
import  Item  from './Item'

export default function ItemList({items, favList}) {
  const checkIfFavorited = (id) => {
    for(const item of favList){
      console.log("itemid:  " + item.id + "   id:  " + id)
      if(item.id == id){
        return true;
      }
      return false;
    }
  }

  return (
    <div>
        {items.map(item => <Item key={item.id} item={item} favorited={() => checkIfFavorited(item.id)}/>)}
    </div>
  )
}
