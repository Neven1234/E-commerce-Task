import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Pages/User/login/login.component';
import { RegisterComponent } from './Pages/User/register/register.component';
import { ViewProductComponent } from './Pages/Product/view-product/view-product.component';
import { ListOfProductsComponent } from './Pages/Product/list-of-products/list-of-products.component';

const routes: Routes = [
  {
    path:'',
    component:ListOfProductsComponent
  },
  {
    path:'Login',
    component:LoginComponent
  },
  {
    path:'Register',
    component:RegisterComponent
  },
  {
    path:'view/:id',
    component:ViewProductComponent
  },

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
