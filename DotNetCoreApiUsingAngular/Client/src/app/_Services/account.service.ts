import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
baseURL = "https://localhost:5001/api/";
  constructor(private http:HttpClient) { }
  Login(model:any){
    return this.http.post(this.baseURL +"Customer/Login",model);
  }
}
