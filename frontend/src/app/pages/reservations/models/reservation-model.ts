export class ReservationModel {
  id: string;
  title: string;
  description: string;
  beginTime: Date;
  endTime: Date;
  isConfirmed?: boolean;
  userId: string;
  roomId: string;
}
