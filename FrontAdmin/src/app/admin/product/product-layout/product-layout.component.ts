import { Component, inject } from '@angular/core';
import { ProductService } from '../../product.service';
import { Product } from '../../Models/product';
import { AttributeService } from '../../attribute.service';
import { TextAttribute } from '../../Models/productAttribute';
import { tap } from 'rxjs';

@Component({
  selector: 'app-product-layout',
  templateUrl: './product-layout.component.html',
  styleUrls: ['./product-layout.component.css']
})
export class ProductLayoutComponent {
  productService = inject(ProductService);
  attrService = inject(AttributeService);

  products: Product[] = [];
  textAttributes: TextAttribute[] = [];

  constructor() {
    this.productService.getProducts().subscribe(x => this.products = x);
    this.attrService.getProductTextAttributes().subscribe(x=>this.textAttributes=x);

    this.attrService.attrCreated.subscribe(x=>{
      this.attrService.getProductTextAttributes().subscribe(x=>this.textAttributes=x);
    });
    
    this.productService.productCreated
    .subscribe(x=>{
      console.log('from layout subs');
      this.productService.getProducts().subscribe(x=>this.products=x);
    });
  }
}
