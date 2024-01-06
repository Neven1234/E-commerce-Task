import { Component, OnInit } from '@angular/core';
import { User } from '../../../Core/interfaces/User';
import { UserService } from '../../../Core/Services/User/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  user:User={
    id:0,
    username:'',
    password:'',
    email:''
  }
  constructor(private userService:UserService,private router:Router){}
  ngOnInit(): void {
       
  }
  Register(){
    this.userService.Register(this.user).subscribe({
      next:(resul)=>{
       console.log(resul)
        this.router.navigate(["Login"])
      },
      error:(res)=>{
        console.log(res)
      }
    })
  }

}
