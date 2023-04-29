import React from 'react';
import { Meal } from '../../../app/models/meal';
import MealListItem from './MealListItem';

interface Props {
  meals: Meal[];
  selectMeal: (id: string) => void;
  deleteMeal: (id: string) => void;
  submitting: boolean;
}

export default function MealList({
  meals,
  selectMeal,
  deleteMeal,
  submitting,
}: Props) {
  return (
    <>
      {meals.map((meal) => (
        <MealListItem
          submitting={submitting}
          key={meal.id}
          meal={meal}
          selectMeal={selectMeal}
          deleteMeal={deleteMeal}
        />
      ))}
    </>
  );
}
