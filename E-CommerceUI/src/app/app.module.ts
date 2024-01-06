import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Pages/User/login/login.component';
import { RegisterComponent } from './Pages/User/register/register.component';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ListOfProductsComponent } from './Pages/Product/list-of-products/list-of-products.component';
import { authInterceptor } from './Core/interceptor/auth.interceptor';
import { HomeComponent } from './Pages/home/home.component';
import { NavComponent } from './Pages/nav/nav.component';
import { ViewProductComponent } from './Pages/Product/view-product/view-product.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ListOfProductsComponent,
    HomeComponent,
    NavComponent,
    ViewProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    
    {
      provide: HTTP_INTERCEPTORS,
      useClass: authInterceptor,
      multi: true
   }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
