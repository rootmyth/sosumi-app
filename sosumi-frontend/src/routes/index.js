// index for router
import React, { useEffect, useState } from 'react';
import { Route, Switch, useHistory } from 'react-router-dom';
import Authenticated from '../pages/Authenticated';
import Navbar from '../components/Navbar/Navbar'
import Specials from '../pages/Specials'
import Menu from '../pages/Menu'
import UserAddress from '../pages/UserAddress'
import Register from '../pages/Register'
import Cart from '../pages/Cart'

export default function Routes({ user }) {
  const [foundUser, setFoundUser] = useState();
  const [fireBaseId, setFireBaseId] = useState(user.$.W);
  const history = useHistory();

  useEffect(() => {
    fetch(
      'https://localhost:7283/api/User/checkIfUserExists/' + user.$.W,
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
        setFoundUser(r);
      });
      console.log("the firebase ID is " + fireBaseId)

      if(!foundUser){
        history.push({
          pathname: "/register",
          state: {FireBaseID: fireBaseId}
        })
      }
    }, [])
    
  return (
    <div>
      <Navbar />
      <Switch>
      <Route path="/register" render={() => <Register fireBaseId={fireBaseId}/>} />
      <Route exact path="/" render ={() => <Authenticated user={user} />} />
      <Route path="/menu" render ={() => <Menu user={user}/>} />
      <Route path="/specials" render ={() => <Specials />} />
      <Route path="/userAddress" render={() => <UserAddress />} />
      <Route path="/cart" render={() => <Cart />} />
      <Route path="*" render ={() => <Authenticated user={user} />} />
    </Switch>
    </div>
  );
}
//<Route exact path="/" component={() => <Authenticated user={user} />} />