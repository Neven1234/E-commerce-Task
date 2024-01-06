import {  HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UserService } from "../Services/User/user.service";

@Injectable()
export class authInterceptor implements HttpInterceptor{
  constructor(private userService:UserService){}
  token:string='eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiTmV2ZW4iLCJqdGkiOiI5ZjQ0ZDIzNi1hNmE0LTQzYjQtYTJiNC1iOGQ5ZDhhY2FmYmQiLCJleHAiOjE3MDQ0OTU0OTYsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTEwNyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMCJ9._BfWpNcYJ7sGuPhF6YmmLGQ7PpT5yic1zu6trisCTps'
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    req=req.clone({
      headers:req.headers.set('Authorization','bearer '+this.userService.GetToken)
    })
    return next.handle(req)
  }
};
