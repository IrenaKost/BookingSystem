import React, { useState } from 'react';
import { Box, Button, TextField, Typography, Modal } from '@mui/material';
import axios from 'axios';
import { toast } from 'react-toastify';
import { Resource } from '../../lib/types';
import { DatePicker } from '@mui/x-date-pickers';
import dayjs from 'dayjs';

interface BookingFormProps {
  open: boolean;
  onClose: () => void;
  resource: Resource;
}

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};


export default function BookingForm({ open, onClose, resource }: BookingFormProps) {
  const [dateFrom, setDateFrom] = useState<string>("");
  const [dateTo, setDateTo] = useState<string>("");
  const [quantity, setQuantity] = useState<number>(1);

  if (!resource) {
    return null;
  }

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    const createBookingDto = {
      resourceId: resource.id,
      dateFrom: dateFrom,
      dateTo: dateTo,
      bookedQuantity: quantity
    };

    try {
      const response = await axios.post<number>('https://localhost:5001/api/bookings', createBookingDto);
      toast.success(`Booking created! ID: ${response.data}`);
      onClose();
    } catch (error) {
    if (axios.isAxiosError(error)) {
      const errorMsg = error?.response?.data || 'Failed to create booking.';
      console.log(error);
      toast.error(errorMsg);
    } else {
      toast.error("Failed to book resource");
    }
    }
  };

  return (
    <Modal open={open} onClose={onClose}>
      <Box sx={style}>
        <Typography variant="h5" gutterBottom color="primary">
          Booking - {resource.name}
        </Typography>
        <Box component='form' display='flex' flexDirection='column' gap={2} onSubmit={handleSubmit}>
        <DatePicker
            label="Date From"
            value={dayjs(dateFrom)}
            onChange={(newValue) => {
              if (newValue) {
                const formattedDate = newValue.format('YYYY-MM-DD');
                setDateFrom(formattedDate);
              }
            }}/>
          <DatePicker
            label="Date To"
            value={dayjs(dateTo)}
            onChange={(newValue) => {
              if (newValue) {
                const formattedDate = newValue.format('YYYY-MM-DD');
                setDateTo(formattedDate);
              }
            }}/>        
          <TextField 
            label='Quantity'
            type='number'
            value={quantity}
            onChange={(e) => setQuantity(parseInt(e.target.value) || 1)}
            required
          />
          <Box display='flex' justifyContent='flex-end' gap={2}>
            <Button color="inherit" onClick={onClose}>Cancel</Button>
            <Button color="success" variant="contained" type="submit">Book</Button>
          </Box>
        </Box>
      </Box>
    </Modal>
  );
}
