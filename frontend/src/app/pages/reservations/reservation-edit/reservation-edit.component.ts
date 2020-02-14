import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {ExceptionService} from '../../../services/exception.service';
import {catchError} from 'rxjs/operators';
import {UserModel} from '../../users/models/user-model';
import {TokenStorageService} from '../../../services/token.storage.service';
import {ReservationService} from '../../../services/reservation.service';

@Component({
  selector: 'app-reservation-edit',
  templateUrl: './reservation-edit.component.html',
  styleUrls: ['./reservation-edit.component.css']
})
export class ReservationEditComponent implements OnInit {
  private currentUser: UserModel;
  private roomId: string;

  private form: FormGroup;
  private formTitle: string;
  private formDescription: string;
  private formBeginTime: string;
  private formEndTime: string;

  constructor(
    private avRoute: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private exceptionService: ExceptionService,
    private reservationService: ReservationService,
    private tokenStorageService: TokenStorageService
  ) {
    this.roomId = this.avRoute.snapshot.params.id;
    this.currentUser = this.tokenStorageService.getUser();

    this.formTitle = 'title';
    this.formDescription = 'description';
    this.formBeginTime = 'beginTime';
    this.formEndTime = 'endTime';

    this.form = this.formBuilder.group({
      title: ['', [Validators.required]],
      description: ['', [Validators.maxLength(500)]],
      beginTime: ['', [Validators.required]],
      endTime: ['', [Validators.required]]
    });
  }

  ngOnInit() {
  }

  get title() {
    return this.form.get(this.formTitle);
  }

  get description() {
    return this.form.get(this.formDescription);
  }

  get beginTime() {
    return this.form.get(this.formBeginTime);
  }

  get endTime() {
    return this.form.get(this.formEndTime);
  }

  save() {
    if (!this.form.valid) {
      return;
    }

    this.reservationService.addReservation({
      title: this.title.value,
      description: this.description.value,
      beginTime: new Date(this.beginTime.value),
      endTime: new Date(this.endTime.value),
      roomId: this.roomId,
      userId: this.currentUser.id
    }).subscribe(() => {
        this.router.navigate(['/room-details', this.roomId]);
      },
      catchError(this.exceptionService.throwError));
  }

  cancel() {
    this.router.navigate(['/room-details', this.roomId]);
  }
}
