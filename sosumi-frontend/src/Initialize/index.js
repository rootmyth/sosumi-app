import React from 'react';
import Loading from '../components/Loading';
import LogIn from '../pages/LogIn';
import Routes from '../routes';
import Main from '../pages/Menu'
import { useAuth } from '../utils/context/authContext';

function Initialize() {
  const { user, userLoading } = useAuth();

  // if user state is null, then show loader
  if (userLoading) {
    return <Loading />;
  }
  console.log(user)
  console.log(user.$.W) // FIREBASE ID
  //(user && user.email exists) ?
  return <>{user ? //check if the email is registered (or firebase id) if so route to <Routes user={user} /> else route to register
  <Routes user={user} /> : <LogIn />}</>;
}
//<Main user={user} />
export default Initialize;
