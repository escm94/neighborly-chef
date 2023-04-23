import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';
import { Meal } from '../models/Meal';

function App() {
  const [meals, setMeals] = useState<Meal[]>([]);

  useEffect(() => {
    axios.get<Meal[]>('http://localhost:5000/api/meals').then((response) => {
      setMeals(response.data);
    });
  }, []);

  return (
    <div>
      <Header as="h2" icon="users" content="Meals" />
      <List>
        {meals.map((meal) => (
          <List.Item key={meal.id}>{meal.name}</List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
