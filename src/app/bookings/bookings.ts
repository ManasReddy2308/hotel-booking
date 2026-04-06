import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-bookings',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './bookings.html',
  styleUrls: ['./bookings.css']
})
export class BookingsComponent {

  checkIn: any;
  checkOut: any;
  totalPrice = 0;
  isAvailable: boolean | null = null;

  roomId = 1;
  userId = 1;

  constructor(private http: HttpClient) {}

  checkAvailability() {

    if (!this.checkIn || !this.checkOut) {
      alert("Select dates first ❗");
      return;
    }

    this.calculatePrice();

    this.http.get<any>(
      `http://localhost:5126/api/bookings/availability?roomId=${this.roomId}&checkIn=${this.checkIn}&checkOut=${this.checkOut}`
    ).subscribe(res => {
      this.isAvailable = res;
    });
  }

  calculatePrice() {
    const days = (new Date(this.checkOut).getTime() - new Date(this.checkIn).getTime()) / (1000 * 60 * 60 * 24);
    this.totalPrice = days * 2000;
  }

  bookRoom() {

    if (!this.checkIn || !this.checkOut) {
      alert("Select dates ❗");
      return;
    }

    const data = {
      userId: this.userId,
      roomId: this.roomId,
      checkInDate: this.checkIn,
      checkOutDate: this.checkOut,
      totalPrice: this.totalPrice
    };

    this.http.post('http://localhost:5126/api/bookings', data)
      .subscribe(() => {
        alert("Booking Successful ✅");
      });
  }
}