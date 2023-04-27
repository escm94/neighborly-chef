import React from 'react';
import { Meal } from '../../../app/models/meal';
import MealListItem from './MealListItem';

interface Props {
  meals: Meal[];
  selectMeal: (id: string) => void;
  deleteMeal: (id: string) => void;
}

export default function MealList({ meals, selectMeal, deleteMeal }: Props) {
  return (
    <>
      {meals.map((meal) => (
        <MealListItem
          key={meal.id}
          meal={meal}
          selectMeal={selectMeal}
          deleteMeal={deleteMeal}
        />
      ))}
    </>
  );
}
