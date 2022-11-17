import React, { useState } from 'react';
import { BrowserRouter, useHistory } from 'react-router-dom';


export default function Register({fireBaseId}) {
const [firstName, setFirstName] = useState('')
const [lastName, setLastName] = useState('')
const [email, setEmail] = useState('')
const [password, setPassword] = useState('')
const history = useHistory();

const favorites = []

    const createUser = (user) => {
        const fetchOptions = {
            method: 'POST',
            headers: {
                'Access-Control-Allow-Origin': 'https://localhost:7283',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(user)
        }
        return fetch('https://localhost:7283/api/User', fetchOptions)
    }

    const submit = () => {
        const dataToSend = {
            "firstName": firstName,
            "lastName": lastName,
            "email": email,
            "password": password,
            "FireBaseId": fireBaseId,
            "favorites": favorites
        }
        createUser(dataToSend)
        history.push('/menu')
    }

    return (
      <div className="text-center mt-5">
        <h1>Welcome! Please Sign Up Below</h1>
        <form onSubmit={submit}>
        <input className="firstName" type="textfield" onChange={(e) => setFirstName(e.target.value)}></input>
        <input className="lastName" type="textfield" onChange={(e) => setLastName(e.target.value)}></input>
        <input className="email" type="textfield" onChange={(e) => setEmail(e.target.value)}></input>
        <input className="password" type="textfield" onChange={(e) => setPassword(e.target.value)}></input>
        <button type="submit" className="btn btn-success">
          Sign Up
        </button>
        </form>
      </div>
    );
  }

