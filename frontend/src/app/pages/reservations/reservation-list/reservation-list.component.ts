import { Component, OnInit } from '@angular/core';
import {ReservationModel} from '../models/reservation-model';
import {RoomService} from '../../../services/room.service';
import {AuthService} from '../../../services/auth.service';
import {RoleService} from '../../../services/role.service';
import {ReservationService} from '../../../services/reservation.service';
import {catchError} from 'rxjs/operators';
import {ExceptionService} from '../../../services/exception.service';
import {format} from 'date-fns';
import {interval, Subscription} from 'rxjs';

@Component({
  selector: 'app-reservation-list',
  templateUrl: './reservation-list.component.html',
  styleUrls: ['./reservation-list.component.css']
})
export class ReservationListComponent implements OnInit {
  private reservations: ReservationModel[];
  private updateSubscription: Subscription;

  constructor(
    private roomService: RoomService,
    private reservationService: ReservationService,
    private authService: AuthService,
    private roleService: RoleService,
    private exceptionService: ExceptionService
  ) {
    this.updateSubscription = interval(10000)
    .subscribe(() => this.loadReservations());
  }

  ngOnInit() {
    this.loadReservations();
  }

  get isManager(): boolean {
    return this.roleService.IsManager;
  }

  getFormatTime(date: Date): string {
    return format(new Date(date), 'dd/MM/yyyy HH:mm');
  }

  editConfirmation(reservationId: string, confirmation: boolean) {
    return this.reservationService.editConfirmationReservation(reservationId, confirmation)
      .subscribe(() => {
          this.loadReservations();
        },
        catchError(this.exceptionService.throwError)
      );
  }

  loadReservations() {
    this.reservationService.getReservations()
      .subscribe(data => {
        this.reservations = data;
      }, catchError(this.exceptionService.throwError));
  }
}
