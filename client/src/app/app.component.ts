import { Component, inject, OnInit } from '@angular/core';
import { NavComponent } from "./nav/nav.component";
import { AccoutService } from './_services/accout.service';
import { HomeComponent } from "./home/home.component";
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavComponent], //HomeComponent
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  private accountService = inject(AccoutService);

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser(){
    const userString = localStorage.getItem('user');
    if (!userString){
      return;
    }
    const user = JSON.parse(userString);
    this.accountService.currentUser.set(user);
  }


}
