import React from 'react';
import { Button, Container, Menu, Icon } from 'semantic-ui-react';

interface Props {
  openForm: () => void;
}

export default function Navbar({ openForm }: Props) {
  return (
    <Menu inverted fixed="top">
      <Container>
        <Menu.Item header>
          <Icon name="food" size="large" style={{ marginRight: '10px' }} />
          Neighborly Chef
        </Menu.Item>
        <Menu.Item name="Meals" />
        <Menu.Item>
          <Button onClick={openForm} positive content="Create Meal" />
        </Menu.Item>
      </Container>
    </Menu>
  );
}
