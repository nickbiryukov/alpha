import {ReservationModel} from '../../reservations/models/reservation-model';

export class RoomWithDetailsModel {
  id: string;
  name: string;
  projector: boolean;
  board: boolean;
  seat: number;
  description: string;
  reservationModels?: ReservationModel[];
}
