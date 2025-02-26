import { useEffect, useState } from 'react'
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import './App.css'

import { Resource } from './lib/types';
import axios from 'axios';
import ResourceList from './features/resources/ResourceList';
import { ToastContainer } from 'react-toastify';
import { ErrorBoundary } from 'react-error-boundary';

function App() {
  const [resources, setResources] = useState<Resource[]>([]);

  useEffect(() => {
    axios.get<Resource[]>('https://localhost:5001/api/resources')
    .then(response => setResources(response.data))
  }, []);

  return (
    <ErrorBoundary fallback={<div>Something went wrong</div>}>
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <h3>ProOffice Booking System</h3>
      <ResourceList resources={resources} selectResource={() => { } } />
      <ToastContainer aria-label={"toast"} />
    </LocalizationProvider>
    //</ErrorBoundary>
  )
}

export default App
