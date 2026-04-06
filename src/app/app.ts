import { Component } from '@angular/core';
import { BookingHistoryComponent } from './booking-history/booking-history';
import { RouterOutlet } from '@angular/router';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [BookingHistoryComponent, RouterOutlet],
  templateUrl: './app.html'
})
export class App {

}