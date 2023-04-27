import React from 'react';
import { Button, ButtonGroup, Card, Icon, Image } from 'semantic-ui-react';
import { Meal } from '../../../app/models/meal';

interface Props {
  meal: Meal;
  cancelSelectMeal: () => void;
  openForm: (id: string) => void;
}

export default function MealDetails({
  meal,
  cancelSelectMeal,
  openForm,
}: Props) {
  return (
    <Card fluid>
      <Image src={'/assets/plate.jpg'} />
      <Card.Content>
        <Card.Header>{meal.name}</Card.Header>
        <Card.Description>{meal.description}</Card.Description>
      </Card.Content>
      <Card.Content extra>
        <ButtonGroup widths={2}>
          <Button
            onClick={() => openForm(meal.id)}
            basic
            color="blue"
            content="Edit"
          ></Button>
          <Button
            onClick={cancelSelectMeal}
            basic
            color="grey"
            content="Cancel"
          ></Button>
        </ButtonGroup>
      </Card.Content>
    </Card>
  );
}
