import { useEffect, useState } from 'react'

import './App.css'
import { Resource } from './lib/types';
import { Button, List, ListItem, ListItemText } from '@mui/material';
import axios from 'axios';

function App() {
  const [resources, setResources] = useState<Resource[]>([]);

  useEffect(() => {
    axios.get<Resource[]>('https://localhost:5001/api/resources')
    .then(response => setResources(response.data))
  }, []);

  return (
    <>
     <h3>ProOffice Booking System</h3>
     <List>
        {resources.map((resource) => (
          <ListItem key={resource.id}>
              <ListItemText>{resource.name}</ListItemText>
              <Button>Book</Button>
          </ListItem>
        ))}
     </List>
    </>   
  )
}

export default App
