import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../Core/Services/Product/product.service';
import { product } from '../../../Core/interfaces/Product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-of-products',
  templateUrl: './list-of-products.component.html',
  styleUrl: './list-of-products.component.css'
})
export class ListOfProductsComponent implements OnInit {

  constructor(private productService:ProductService,private router:Router){}
  products:product[]=[];
  isLogged:boolean=false
  ngOnInit(): void {
    if (typeof window !== 'undefined' && window.document)
    {
      var token=localStorage.getItem('token')
      if(token!=undefined)
      {
        this.isLogged=true
        this.productService.GetProducts().subscribe({
          next:(products)=>{
            this.products=products
            console.log('tm')
          },
          error:(error)=>{
            console.log(error)
          }
        })
      }
      else
      {
        this.isLogged=false;
      }
    }
    
   
    
  }
  View(id:number){
    this.router.navigate(['view/'+id])
  }

}
