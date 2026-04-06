import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class DashboardComponent {

  locations = ['New York', 'Miami', 'Denver'];

  selectedLocation = '';
  maxPrice: number | null = null;

  hotels = [
    {
      name: 'Grand Luxury Hotel',
      location: 'New York',
      price: 800,
      image: 'https://source.unsplash.com/400x250/?luxury-hotel'
    },
    {
      name: 'City Comfort Inn',
      location: 'New York',
      price: 500,
      image: 'https://source.unsplash.com/400x250/?city-hotel'
    },
    {
      name: 'Seaside Paradise Resort',
      location: 'Miami',
      price: 700,
      image: 'https://source.unsplash.com/400x250/?beach-resort'
    },
    {
      name: 'Ocean Breeze Stay',
      location: 'Miami',
      price: 400,
      image: 'https://source.unsplash.com/400x250/?beach-hotel'
    },
    {
      name: 'Mountain View Lodge',
      location: 'Denver',
      price: 600,
      image: 'https://source.unsplash.com/400x250/?mountain-hotel'
    }
  ];

  filteredHotels = [...this.hotels];

  filterHotels() {
    this.filteredHotels = this.hotels.filter(hotel => {

      const matchLocation =
        this.selectedLocation === '' ||
        hotel.location === this.selectedLocation;

      const matchPrice =
        this.maxPrice === null ||
        hotel.price <= this.maxPrice;

      return matchLocation && matchPrice;
    });
  }
  logout() {
    localStorage.clear();
    window.location.href = '/';
  }
}