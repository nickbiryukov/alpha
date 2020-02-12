import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {ExceptionService} from '../../../services/exception.service';
import {RoomService} from '../../../services/room.service';
import {RoomModel} from '../models/room-model';
import {catchError} from 'rxjs/operators';

@Component({
  selector: 'app-room-edit',
  templateUrl: './room-edit.component.html',
  styleUrls: ['./room-edit.component.css']
})
export class RoomEditComponent implements OnInit {
  private actionType: string;

  private roomId: string;
  private existingRoom: RoomModel;

  private form: FormGroup;
  private formName: string;
  private formDescription: string;
  private formBoard: string;
  private formProjector: string;
  private formSeat: string;

  constructor(
    private roomService: RoomService,
    private formBuilder: FormBuilder,
    private avRoute: ActivatedRoute,
    private router: Router,
    private exceptionService: ExceptionService
  ) {
    const idParam = 'id';

    this.actionType = 'Add';

    this.formName = 'name';
    this.formDescription = 'description';
    this.formBoard = 'board';
    this.formProjector = 'projector';
    this.formSeat = 'seat';

    if (this.avRoute.snapshot.params[idParam]) {
      this.roomId = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group({
      userId: '',

      name: ['', [Validators.required]],
      description: ['', [Validators.required]],
      board: [false, [Validators.required]],
      projector: [false, [Validators.required]],
      seat: [0, [Validators.required]]
    });
  }

  get name() {
    return this.form.get(this.formName);
  }

  get description() {
    return this.form.get(this.formDescription);
  }

  get board() {
    return this.form.get(this.formBoard);
  }

  get projector() {
    return this.form.get(this.formProjector);
  }

  get seat() {
    return this.form.get(this.formSeat);
  }

  ngOnInit() {
    if (this.roomId) {
      this.actionType = 'Edit';
      this.roomService.getRoom(this.roomId)
        .subscribe(data => (
          this.existingRoom = data,
            this.form.controls[this.formName].setValue(data.name),
            this.form.controls[this.formDescription].setValue(data.description),
            this.form.controls[this.formBoard].setValue(data.board),
            this.form.controls[this.formProjector].setValue(data.projector),
            this.form.controls[this.formSeat].setValue(data.seat)
        ));
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }

    if (this.actionType === 'Add') {
      this.roomService.addRoom({
        name: this.name.value,
        description: this.description.value,
        board: this.board.value,
        projector: this.projector.value,
        seat: this.seat.value
      }).subscribe(() => {
          this.router.navigate(['room-list']);
        },
        catchError(this.exceptionService.throwError));
    }

    if (this.actionType === 'Edit') {
      this.roomService.editRoom(this.roomId, {
        name: this.name.value,
        description: this.description.value,
        board: this.board.value,
        projector: this.projector.value,
        seat: this.seat.value
      }).subscribe((data) => {
          this.router.navigate(['room-list']);
        },
        catchError(this.exceptionService.throwError));
    }
  }

  cancel() {
    this.router.navigate(['/room-list']);
  }

}
