import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_Services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private accountService:AccountService) { }
Model:any={};
loggedIn:Boolean;
  ngOnInit() {
  }
  Login(){
    this.accountService.Login(this.Model).subscribe(
      options => {
        console.log(options)
        this.loggedIn = true;
      }
      
    ),error =>console.log(error);
  }
  Logout(){
    this.loggedIn = false;
  }

}
