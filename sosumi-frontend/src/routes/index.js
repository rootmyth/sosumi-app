// index for router
import React from 'react';
import { Route, Switch } from 'react-router-dom';
import Authenticated from '../pages/Authenticated';
import Navbar from '../components/Navbar/navbar'

export default function Routes({ user }) {
  return (
    <div>
      <Navbar />
      <Switch>
        <Route exact path="/" component={() => <Authenticated user={user} />} />
        <Route path="*" component={() => <Authenticated user={user} />} />
      </Switch>
    </div>
  );
}
