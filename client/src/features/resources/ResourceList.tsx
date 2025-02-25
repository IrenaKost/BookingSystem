import { Box, List, ListItem } from "@mui/material";
import { Resource } from "../../lib/types";

type Props = {
    resources: Resource[]
    selectResource: (id: string) => void;
}

export default function ActivityList({resources, selectResource}: Props) {
  return (
    <Box sx={{display: 'flex', flexDirection: 'column', gap: 3}}>
        <List>
        {resources.map(activity => (
            <ListItem
            <ListItem key={resource.id}>
            <ListItemText>{resource.name}</ListItemText>
            <Button>Book</Button>
        </ListItem>


              
              activity={activity} 
              selectActivity={selectActivity}  
              deleteActivity={deleteActivity}
            />
        ))}
        </List>
    </Box>
  )
}