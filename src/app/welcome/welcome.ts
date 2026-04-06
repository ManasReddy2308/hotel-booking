import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-welcome',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './welcome.html',
  styleUrl: './welcome.css'
})
export class WelcomeComponent {

  constructor(private router: Router, private auth: AuthService) {}

  guestLogin() {
    this.auth.guestLogin().subscribe(() => {
      localStorage.setItem('role', 'guest');
      this.router.navigate(['/dashboard']);
    });
  }
}