export class ReservationModel {
  id: string;
  title: string;
  description: string;
  beginTime: Date;
  endTime: Date;
  isConfirmed: boolean | null;
  userId: string;
  roomId: string;
}
