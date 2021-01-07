import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/product.model';
import { ProductService } from 'src/app/shared/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  productModel : Array<Product> = new Array<Product>();
  constructor(private productService:ProductService) { }

  ngOnInit(): void {
  }
  AddProduct(Code){

  }

}
