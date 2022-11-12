// index for router
import React from 'react';
import { Route, Switch } from 'react-router-dom';
import Authenticated from '../pages/Authenticated';
import Navbar from '../components/Navbar/navbar'
import Specials from '../pages/Specials'
import Menu from '../pages/Menu'

export default function Routes({ user }) {
  return (
    <div>
      <Navbar />
      <Switch>
      <Route exact path="/" render ={() => <Authenticated user={user} />} />
      <Route path="/menu" render ={() => <Menu />} />
      <Route path="/special" render ={() => <Specials />} />
      <Route path="*" render ={() => <Authenticated user={user} />} />
    </Switch>
    </div>
  );
}
//<Route exact path="/" component={() => <Authenticated user={user} />} />