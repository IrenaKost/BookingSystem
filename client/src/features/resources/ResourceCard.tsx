import { Card, CardContent, CardActions, Typography, Box, Button } from "@mui/material";
import { Resource } from "../../lib/types";

type Props = {
    resource: Resource
    selectResource: (id: number) => void;
    bookResource: (resource: Resource) => void;
  }

  export default function ResourceCard({ resource, selectResource, bookResource }: Props) {
    return (
      <Card sx={{ borderRadius: 3 }}>
        <CardContent>
          <Typography variant="h5">{resource.name}</Typography>
          <Typography variant="subtitle1">"Total quantity: "{resource.quantity}</Typography>
        </CardContent>
        <CardActions sx={{ display: 'flex', justifyContent: 'space-between', pb: 2 }}>         
          <Box display='flex' gap={3}>
            <Button onClick={() => selectResource(resource.id)} size="medium"
              variant="contained">View</Button>               
            <Button onClick={() => bookResource(resource)} color='primary' size="medium"
            variant="contained">Book</Button>            
          </Box>
        </CardActions>
      </Card>
    )
  }