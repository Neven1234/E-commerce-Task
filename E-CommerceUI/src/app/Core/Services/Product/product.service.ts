import { Injectable } from '@angular/core';
import { MasterService } from '../Master/master.service';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { ApiEndPoint } from '../../Constant/Constants';
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private master:MasterService) { }
  baseUrl:string=environment.baseUrl
  //Get all products
  public GetProducts():Observable<any>{
    return this.master.get(this.baseUrl+ApiEndPoint.Produce.GetAllProducts)
  }

  //GetOneProduct
  public GetProduct(id:number):Observable<any>{
    return this.master.get(this.baseUrl+ApiEndPoint.Produce.GetProductBuyId+'/'+id)
  }
}
