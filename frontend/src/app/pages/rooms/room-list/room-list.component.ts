import {Component, OnInit} from '@angular/core';
import {Observable} from 'rxjs';
import {RoomService} from '../../../services/room.service';
import {RoomWithDetailsModel} from '../models/room-with-details';
import {AuthService} from '../../../services/auth.service';
import {RoleService} from '../../../services/role.service';
import { format, compareAsc } from 'date-fns';
import {catchError, retry} from 'rxjs/operators';
import {ExceptionService} from '../../../services/exception.service';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.css']
})
export class RoomListComponent implements OnInit {

  private rooms: RoomWithDetailsModel[];

  constructor(
    private roomService: RoomService,
    private authService: AuthService,
    private roleService: RoleService,
    private exceptionService: ExceptionService
  ) {
  }

  get isManager(): boolean {
    return this.roleService.IsManager;
  }

  ngOnInit() {
    this.loadRooms();
  }

  getEarlierDate(room: RoomWithDetailsModel): string {
    const reservation = room.reservationModels[0];

    if (!reservation) {
      return 'Free';
    } else {
      const beginTime = this.getFormatTime(reservation.beginTime);
      const endTime = this.getFormatTime(reservation.endTime);
      return `${beginTime} - ${endTime}`;
    }
  }

  getFormatTime(date: Date): string {
    return format(new Date(date), 'dd/MM/yyyy HH:mm');
  }

  loadRooms() {
     this.roomService.getRoomWithDetails()
      .subscribe(data => {
        this.rooms = data;
    }, catchError(this.exceptionService.throwError));
  }

  delete(roomId: string, name: string) {
    const ans = confirm('Do you want to delete room? ' + name);
    if (ans) {
      this.roomService.deleteRoom(roomId)
        .subscribe(() => this.loadRooms());
    }
  }
}
