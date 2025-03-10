import { Component, OnInit } from '@angular/core';
import { BookingRm, BookDto } from '../api/models';
import { BookingService } from './../api/services/booking.service';
import { AuthService } from './../auth/auth.service';


@Component({
  selector: 'app-my-bookings',
  templateUrl: './my-bookings.component.html',
  styleUrls: ['./my-bookings.component.css']
})
export class MyBookingsComponent {

  bookings!: BookingRm[];
  constructor(private bookingService: BookingService, private authService: AuthService) {

  }
  ngOnInit(): void {
  
      this.bookingService.listBooking({email: this.authService.currentuser?.email?? ''})
      .subscribe(r => this.bookings = r, this.handleError);
  }

  private handleError(err:any) {
    console.log("Response error: ", err.status);
    console.log(err);
  }
  cancel(booking: BookingRm) {
    const dto: BookDto = {
      flightId: booking.flightId,
      numberOfSeats: booking.numberOfBookedSeats,
      passengerEmail: booking.passengerEmail
    }
    this.bookingService.cancelBooking({
      body: dto
    }).subscribe(_ => { this.bookings = this.bookings.filter(b => b != booking) }, this.handleError);
  }
}
