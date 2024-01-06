import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppComponent } from '../../app.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  constructor(private appComp:AppComponent){}
  ngOnInit(): void {
    if (typeof window !== 'undefined' && window.document)
    {
      var token=localStorage.getItem('token')
    if(token!=null)
    {
      this.appComp.IsLogged==true
    }
    }
    
  }
  
}
