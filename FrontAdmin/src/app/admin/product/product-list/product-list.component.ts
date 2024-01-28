import { Component, Input, inject } from '@angular/core';
import { ProductService } from '../../product.service';
import { Product } from '../../Models/product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent {
  productService = inject(ProductService);

  @Input() allProducts: Product[] = [];

}
