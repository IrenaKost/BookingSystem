import { Box } from "@mui/material";
import { Resource } from "../../lib/types";
import ResourceCard from "./ResourceCard";
import { useState } from "react";
import BookingForm from "../bookings/BookingForm";

type Props = {
  resources: Resource[]
  selectResource: (id: number) => void;
}

export default function ResourceList({ resources, selectResource }: Props) {

  const [open, setOpen] = useState(false)
  const [selectedResource, setSelectedResource] = useState<Resource | null>(null)

  return (
    <>
    <Box sx={{ display: 'flex', flexDirection: 'column', gap: 3 }}>
      {resources.map(resource => (
        <ResourceCard
          key={resource.id}
          resource={resource}
          selectResource={selectResource}
          bookResource={resource => {
            setOpen(true);
            setSelectedResource(resource);
          }} />
      ))}
    </Box>
      <BookingForm open={open} resource={selectedResource!} onClose={() => {setOpen(false)
        setSelectedResource(null)
      }} />
    </>
  )
}