import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {RoomModel} from '../models/room-model';
import {RoomService} from '../../../services/room.service';
import {RoomWithDetails} from '../models/room-with-details';
import {AuthService} from '../../../services/auth.service';
import {RoleService} from '../../../services/role.service';
import {Time} from '@angular/common';

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

  ngOnInit() {
    this.loadRooms();
  }

  get isManager(): boolean {
    return this.roleService.IsManager;
  }

  getEarlierTime(room: RoomWithDetails): string {
    const reservation = room.reservationModels[0];

    if (!reservation) {
      return 'Free';
    } else {
      const date = new Date(reservation.date).getDate();
      const beginTime = reservation.beginTime.hours;
      const endTime = reservation.endTime.hours;

      return `${date} (${beginTime}-${endTime})`;
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
