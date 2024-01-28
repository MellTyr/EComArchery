import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable,Subject, tap } from 'rxjs';
import { Product } from './Models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url = 'http://localhost:5000';
  http = inject(HttpClient);

  constructor() { }

  getProducts(): Observable<Product[]> {
    let prodObs = this.http.get<Product[]>(`${this.url}/api/Product/GetProducts`);
    return prodObs;
  }

  createProduct(product:Product):Observable<number>{
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    let obs = this.http.post<number>(`${this.url}/api/Product/Create`,
     JSON.stringify(product), { headers: headers })
     .pipe(tap(x=>this.productCreated.next(x)))
     .pipe(tap(x=>console.log('product created!!!!', x)));
     return obs;
  }

  productCreated:Subject<number> = new Subject<number>();
}
