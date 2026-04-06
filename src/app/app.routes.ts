import { Routes } from '@angular/router';
import { BookingHistoryComponent } from './booking-history/booking-history';
import { LoginComponent } from './login/login';
import { RegisterComponent } from './register/register';
import { WelcomeComponent } from './welcome/welcome';
import { DashboardComponent } from './dashboard/dashboard';
export const routes: Routes = [
    { path: '', component: WelcomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'my-bookings', component: BookingHistoryComponent }
];
