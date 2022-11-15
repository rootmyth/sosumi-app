// index for router
import React from 'react';
import { Route, Switch } from 'react-router-dom';
import Authenticated from '../pages/Authenticated';
import Navbar from '../components/Navbar/Navbar'
import Specials from '../pages/Specials'
import Menu from '../pages/Menu'
import UserAddress from '../pages/UserAddress'

export default function Routes({ user }) {
  return (
    <div>
      <Navbar />
      <Switch>
      <Route exact path="/" render ={() => <Authenticated user={user} />} />
      <Route path="/menu" render ={() => <Menu />} />
      <Route path="/specials" render ={() => <Specials />} />
      <Route path="/userAddress" render={() => <UserAddress />} />
      <Route path="*" render ={() => <Authenticated user={user} />} />
    </Switch>
    </div>
  );
}
//<Route exact path="/" component={() => <Authenticated user={user} />} />