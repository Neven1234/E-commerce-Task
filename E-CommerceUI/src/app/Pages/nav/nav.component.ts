import { Component } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  IsLogged:boolean=false
  Clicked:boolean=false
  public LogOut(){
    localStorage.removeItem('token');
    this.IsLogged=false;

  }
}
