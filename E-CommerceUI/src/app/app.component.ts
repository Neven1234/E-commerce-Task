import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
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
  title = 'E-CommerceUI';
  IsLogged:boolean=false
  Clicked:boolean=false
  public LogOut(){
    localStorage.clear();
    this.IsLogged=false;

  }
  
}
