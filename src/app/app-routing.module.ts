import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductComponent } from './products/product/product.component';
import { ProductsComponent } from './products/products.component';


const routes: Routes = [
{path:'',redirectTo:'product',pathMatch:'full'},
{path:'products',component:ProductsComponent},
{path:'product',children:[
  {path:'',component:ProductComponent},
  {path:'edit/:id',component:ProductComponent}
]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
