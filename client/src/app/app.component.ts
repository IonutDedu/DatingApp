import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  http = inject(HttpClient);
  title = 'DatingApp';
  users: any;

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/users').subscribe({ // subscribe to Observable to actually do something
      next: response => this.users = response, //()=>{} = does nothing
      error: error => console.log(error), //()=>{},
      complete: ()=> console.log("Request has completed!")  //()=>{} // no need for unsubscribe for http requests 
    })
  }

}
