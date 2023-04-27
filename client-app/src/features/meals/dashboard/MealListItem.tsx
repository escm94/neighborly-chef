import react from 'react';
import { Button, Item, Segment } from 'semantic-ui-react';
import { Meal } from '../../../app/models/meal';

interface Props {
  meal: Meal;
  selectMeal: (id: string) => void;
  deleteMeal: (id: string) => void;
}

export default function MealListItem({ meal, selectMeal, deleteMeal }: Props) {
  return (
    <Segment.Group>
      <Segment>
        <Item.Group>
          <Item>
            <Item.Image size="small" src="/assets/plate.jpg" />
            <Item.Content>{meal.name}</Item.Content>
          </Item>
        </Item.Group>
      </Segment>
      <Segment clearing>
        <span>{meal.description}</span>
        <Button
          onClick={() => selectMeal(meal.id)}
          color="blue"
          floated="right"
          content="View"
        />
        <Button
          onClick={() => deleteMeal(meal.id)}
          color="red"
          floated="right"
          content="Delete"
        />
      </Segment>
    </Segment.Group>
  );
}
