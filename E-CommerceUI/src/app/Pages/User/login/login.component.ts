import { Component, OnInit } from '@angular/core';
import { User } from '../../../Core/interfaces/User';
import { UserService } from '../../../Core/Services/User/user.service';
import { Router } from '@angular/router';
import { AppComponent } from '../../../app.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  user:User={
    id:0,
    username:'',
    password:'',
    email:'',
    
  }
  constructor(private userService:UserService,private router:Router,private appComp:AppComponent){}
  ngOnInit(): void {
   
  }
  LogIn(){
    this.userService.Login(this.user).subscribe({
      next:(resul)=>{
        
        console.log('to :'+resul)
        localStorage.setItem('token',resul)
        this.appComp.IsLogged=true
        setTimeout( () => { window.location.reload() }, 500 );
        this.router.navigate([''])
      },
      error:(res)=>{
        console.log(res)
      }
    })
  }
  Register(){
    this.router.navigate(["Register"])
  }
}
