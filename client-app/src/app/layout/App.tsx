import React, { useEffect, useState } from 'react';
import { Container } from 'semantic-ui-react';
import Navbar from './Navbar';
import MealDashboard from '../../features/meals/dashboard/MealDashboard';
import { Meal } from '../models/meal';
import { v4 as uuid } from 'uuid';
import agent from '../api/agent';
import LoadingComponent from './LoadingComponent';

function App() {
  const [meals, setMeals] = useState<Meal[]>([]);
  const [selectedMeal, setSelectedMeal] = useState<Meal | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);
  const [submitting, setSubmitting] = useState(false);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    agent.Meals.list().then((response) => {
      setMeals(response);
      setLoading(false);
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
    setSubmitting(true);
    if (meal.id) {
      agent.Meals.update(meal).then(() => {
        setMeals([...meals.filter((x) => x.id !== meal.id), meal]);
        setSelectedMeal(meal);
        setEditMode(false);
        setSubmitting(false);
      });
    } else {
      meal.id = uuid();
      agent.Meals.create(meal).then(() => {
        setMeals([...meals, meal]);
        setSelectedMeal(meal);
        setEditMode(false);
        setSubmitting(false);
      });
    }
  }

  function handleDeleteMeal(id: string) {
    setSubmitting(true);
    agent.Meals.delete(id).then(() => {
      setMeals([...meals.filter((x) => x.id !== id)]);
      setSubmitting(false);
    });
  }

  if (loading)
    return <LoadingComponent content="Loading app"></LoadingComponent>;

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
          submitting={submitting}
        />
      </Container>
    </>
  );
}

export default App;
