import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {RoomModel} from '../models/room-model';
import {RoomService} from '../../../services/room.service';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.css']
})
export class RoomListComponent implements OnInit {

  rooms$: Observable<RoomModel[]>;

  constructor(private roomService: RoomService) {
  }

  ngOnInit() {
    this.loadRooms();
  }

  loadRooms() {
    this.rooms$ = this.roomService.getRooms();
  }
}
