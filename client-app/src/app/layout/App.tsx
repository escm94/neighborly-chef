import React, { useEffect, useState } from 'react';
import { Container } from 'semantic-ui-react';
import Navbar from './Navbar';
import MealDashboard from '../../features/meals/dashboard/MealDashboard';
import { Meal } from '../models/meal';
import { v4 as uuid } from 'uuid';
import agent from '../api/agent';

function App() {
  const [meals, setMeals] = useState<Meal[]>([]);
  const [selectedMeal, setSelectedMeal] = useState<Meal | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);

  useEffect(() => {
    agent.Meals.list().then((response) => {
      setMeals(response);
    });
  }, []);

  function handleSelectMeal(id: string) {
    setSelectedMeal(meals.find((x) => x.id === id));
  }

  function handleCancelSelectMeal() {
    setSelectedMeal(undefined);
  }

  function handleFormOpen(id?: string) {
    id ? handleSelectMeal(id) : handleCancelSelectMeal();
    setEditMode(true);
  }

  function handleFormClose() {
    setEditMode(false);
  }

  function handleCreateOrEditMeal(meal: Meal) {
    meal.id
      ? setMeals([...meals.filter((x) => x.id !== meal.id), meal])
      : setMeals([...meals, { ...meal, id: uuid() }]);
    setEditMode(false);
    setSelectedMeal(meal);
  }

  function handleDeleteMeal(id: string) {
    setMeals([...meals.filter((x) => x.id !== id)]);
  }

  return (
    <>
      <Navbar openForm={handleFormOpen} />
      <Container style={{ marginTop: '7em' }}>
        <MealDashboard
          meals={meals}
          selectedMeal={selectedMeal}
          selectMeal={handleSelectMeal}
          cancelSelectMeal={handleCancelSelectMeal}
          editMode={editMode}
          openForm={handleFormOpen}
          closeForm={handleFormClose}
          createOrEdit={handleCreateOrEditMeal}
          deleteMeal={handleDeleteMeal}
        />
      </Container>
    </>
  );
}

export default App;
