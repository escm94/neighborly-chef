import React from 'react';
import { Grid } from 'semantic-ui-react';
import MealList from './MealList';
import MealDetails from '../details/MealDetails';
import { Meal } from '../../../app/models/meal';
import MealForm from '../form/MealForm';

interface Props {
  meals: Meal[];
  selectedMeal: Meal | undefined;
  selectMeal: (id: string) => void;
  cancelSelectMeal: () => void;
  editMode: boolean;
  openForm: (id: string) => void;
  closeForm: () => void;
  createOrEdit: (meal: Meal) => void;
  deleteMeal: (id: string) => void;
  submitting: boolean;
}

export default function MealDashboard({
  meals,
  selectedMeal,
  selectMeal,
  cancelSelectMeal,
  editMode,
  openForm,
  closeForm,
  createOrEdit,
  deleteMeal,
  submitting,
}: Props) {
  return (
    <Grid>
      <Grid.Column width={12}>
        <MealList
          meals={meals}
          selectMeal={selectMeal}
          deleteMeal={deleteMeal}
          submitting={submitting}
        />
      </Grid.Column>
      <Grid.Column width={4}>
        {selectedMeal && !editMode && (
          <MealDetails
            meal={selectedMeal}
            cancelSelectMeal={cancelSelectMeal}
            openForm={openForm}
          ></MealDetails>
        )}
        {editMode && (
          <MealForm
            closeForm={closeForm}
            meal={selectedMeal}
            createOrEdit={createOrEdit}
            submitting={submitting}
          />
        )}
      </Grid.Column>
    </Grid>
  );
}
