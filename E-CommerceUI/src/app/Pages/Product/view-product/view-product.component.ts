import { Component, OnInit } from '@angular/core';
import { product } from '../../../Core/interfaces/Product';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../../Core/Services/Product/product.service';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrl: './view-product.component.css'
})
export class ViewProductComponent implements OnInit {
 
  constructor(private route:ActivatedRoute,private productService:ProductService){}
  
  product:product={
    image:'',
    name:'',
    minimumQuantity:0,
    productCode:0,
    price:0,
    discountRate:0,
    category:'',
    id:0
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=Number( params.get('id'));
        if(id){
          this.productService.GetProduct(id).subscribe({
            next:(product)=>{
              this.product=product
              console.log(this.product.name)
            },
            error:(error)=>{
              console.log(error)
            }
          })
        }
      }
    })
  }
  
}
