import { Component, OnInit } from '@angular/core';
import { CommonModule, DatePipe, NgClass } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { HttpClientModule } from '@angular/common/http';
import { BookingService } from './booking.service';

@Component({
  selector: 'my-bookings',
  standalone: true,
  imports: [
    CommonModule,
    MatIconModule,
    MatButtonModule,
    HttpClientModule,
    DatePipe,
    NgClass
  ],
  templateUrl: './booking-history.html',
  styleUrls: ['./booking-history.css']
})
export class BookingHistoryComponent implements OnInit {

  bookings:any[] = [];

  constructor(private service:BookingService){}

  ngOnInit(): void {
    this.loadBookings();
  }

  loadBookings(){
    this.service.getBookings().subscribe({
      next:(res:any)=>{
        this.bookings = res;
      }
    })
  }

  cancel(id:number){
    this.service.cancelBooking(id).subscribe(()=>{
      this.loadBookings();
    })
  }

}