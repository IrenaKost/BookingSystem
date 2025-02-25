import { Box, Button, Paper, TextField, Typography } from "@mui/material";

export default function BookingForm() {
    return (
        <Paper sx={{borderRadius: 3, padding: 3}}>
            <Typography variant="h3" gutterBottom color="primary">
                 Booking - Selected Resource Name
            </Typography>
            <Box component='form' display='flex' flexDirection='column' gap={3}>
                <TextField label='DateFrom' type='datetime'/>
                <TextField label='DateTo' type='datetime' />
                <TextField label='Quantity'/>
                <Box display='flex' justifyContent='end' gap={3}>
                    <Button color="inherit">Cancel</Button>
                    <Button color="success" variant="contained">Book</Button>
                </Box>
            </Box>
        </Paper>
    )
}