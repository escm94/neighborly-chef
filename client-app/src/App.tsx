import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  const [meals, setMeals] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/meals').then((response) => {
      setMeals(response.data);
    });
  }, []);

  return (
    <div>
      <Header as="h2" icon="users" content="Meals" />
      <List>
        {meals.map((meal: any) => (
          <List.Item key={meal.id}>{meal.name}</List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;