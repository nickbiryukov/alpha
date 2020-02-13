import {Component, OnInit} from '@angular/core';
import {Observable} from 'rxjs';
import {RoomService} from '../../../services/room.service';
import {RoomWithDetails} from '../models/room-with-details';
import {AuthService} from '../../../services/auth.service';
import {RoleService} from '../../../services/role.service';
import { format, compareAsc } from 'date-fns';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.css']
})
export class RoomListComponent implements OnInit {

  private rooms: Observable<RoomWithDetails[]>;

  constructor(
    private roomService: RoomService,
    private authService: AuthService,
    private roleService: RoleService
  ) {
  }

  get isManager(): boolean {
    return this.roleService.IsManager;
  }

  ngOnInit() {
    this.loadRooms();
  }

  getEarlierTime(room: RoomWithDetails): string {
    const reservation = room.reservationModels[0];

    if (!reservation) {
      return 'Free';
    } else {
      const beginTime = format(reservation.beginTime, 'dd-MM-yyyy HH:mm');
      const endTime = format(reservation.endTime, 'dd-MM-yyyy HH:mm');

      return `${beginTime} - ${endTime}`;
    }
  }

  loadRooms() {
    this.rooms = this.roomService.getRoomWithDetails();
  }

  delete(roomId: string, name: string) {
    const ans = confirm('Do you want to delete room? ' + name);
    if (ans) {
      this.roomService.deleteRoom(roomId)
        .subscribe(() => this.loadRooms());
    }
  }
}
