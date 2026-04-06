import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  private api = "https://localhost:5126/api/book";

  constructor(private http:HttpClient){}

  getBookings(){

    const token = localStorage.getItem("token");

    return this.http.get(`${this.api}/my-bookings`,{
      headers:{
        Authorization:`Bearer ${token}`
      }
    })
  }

  cancelBooking(id:number){

    const token = localStorage.getItem("token");

    return this.http.put(`${this.api}/cancel/${id}`,{},{
      headers:{
        Authorization:`Bearer ${token}`
      }
    })

  }

}