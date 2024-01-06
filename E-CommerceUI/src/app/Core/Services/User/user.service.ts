import { Injectable } from '@angular/core';
import { MasterService } from '../Master/master.service';
import { User } from '../../interfaces/User';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { ApiEndPoint } from '../../Constant/Constants';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseURL:string=environment.baseUrl;
  constructor(private master:MasterService) { }


  public Login(user:User):Observable<any>{
    return this.master.post(this.baseURL+ApiEndPoint.User.Login,user)
  }

  public Register(user:User):Observable<any>{
    const options = {responseType: 'text' as 'json'};
    return this.master.post(this.baseURL+ApiEndPoint.User.Register,user)
  }
  get GetToken(){
    if (typeof window !== 'undefined' && window.document)
    {
      return localStorage.getItem('token')
    }
    else
    {
      return  undefined;
    }
     
    
  }
}
