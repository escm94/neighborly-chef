import React, { ChangeEvent, useState } from 'react';
import { Button, Form, Segment } from 'semantic-ui-react';
import { Meal } from '../../../app/models/meal';

interface Props {
  meal: Meal | undefined;
  closeForm: () => void;
  createOrEdit: (meal: Meal) => void;
  submitting: boolean;
}

export default function MealForm({
  meal: selectedMeal,
  closeForm,
  createOrEdit,
  submitting,
}: Props) {
  const initialState = selectedMeal ?? {
    id: '',
    name: '',
    description: '',
  };

  const [meal, setMeal] = useState(initialState);

  const handleSubmit = () => {
    createOrEdit(meal);
  };

  const handleInputChange = (
    event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = event.target;
    setMeal({ ...meal, [name]: value });
  };

  return (
    <Segment clearing>
      <Form onSubmit={handleSubmit} autoComplete="off">
        <Form.Input
          placeholder="Name"
          value={meal.name}
          name="name"
          onChange={handleInputChange}
        ></Form.Input>
        <Form.TextArea
          placeholder="Description"
          value={meal.description}
          name="description"
          onChange={handleInputChange}
        ></Form.TextArea>
        <Button
          loading={submitting}
          floated="right"
          positive
          type="submit"
          content="Submit"
        />
        <Button
          onClick={closeForm}
          floated="right"
          type="button"
          content="Cancel"
        />
      </Form>
    </Segment>
  );
}
