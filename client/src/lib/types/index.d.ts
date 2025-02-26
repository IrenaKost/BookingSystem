export interface Resource {
    id: number
    name: string
    quantity: number
    bookings: unknown[]
  }

  export interface CreateBookingInputDto {
    resourceId: number;
    dateFrom: string;
    dateTo: string;
    bookedQuantity: number;
  }