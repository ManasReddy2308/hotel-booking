import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, RouterModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class RegisterComponent {

  name = '';
  email = '';
  password = '';

  constructor(private auth: AuthService, private router: Router) {}

  register() {
    this.auth.register(this.name, this.email, this.password).subscribe({
      next: () => {
        alert('Registered successfully');
        this.router.navigate(['/login']);
      },
      error: () => alert('Registration failed')
    });
  }
}