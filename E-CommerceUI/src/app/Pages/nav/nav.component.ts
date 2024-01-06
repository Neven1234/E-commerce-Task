import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent implements OnInit {
  IsLogged:boolean=false
  Once:boolean=false
  ngOnInit(): void {
    if (typeof window !== 'undefined' && window.document)
    {
      var token=localStorage.getItem('token')
    if(token!=null)
    {
      this.IsLogged=true

      
    }
    else{
      this.IsLogged=false
    }
    }
  }
 
  
  public LogOut(){
    localStorage.clear();
    window.location.reload()
    this.IsLogged=false;

  }
}
