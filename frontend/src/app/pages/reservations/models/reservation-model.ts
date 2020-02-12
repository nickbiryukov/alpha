import {Time} from '@angular/common';

export class ReservationModel {
  id: string;
  title: string;
  description: string;
  date: Date;
  beginTime: Time;
  endTime: Time;
  isConfirmed?: boolean;
  userId: string;
  roomId: string;
}
