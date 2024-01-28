import { Injectable, inject } from '@angular/core';
import { TextAttribute, choiseAttribute } from './Models/productAttribute';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, Subject, finalize, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AttributeService {
  url = 'http://localhost:5000';
  http = inject(HttpClient);
  constructor() { }

  getProductTextAttributes(): Observable<TextAttribute[]> {
    let obs = this.http.get<TextAttribute[]>(`${this.url}/api/ProductAttributes/GetTextAttributes`);
    return obs;
  }

  getChoiseAttributes(): Observable<choiseAttribute[]> {
    let obs = this.http.get<choiseAttribute[]>(`${this.url}/api/ProductAttributes/GetChoiseAttributes`);
    return obs;
  }

  attrCreated: Subject<number> = new Subject();

  createTextAttribute(productTextAtt: TextAttribute): Observable<number> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    
    let obs = this.http.post<number>(`${this.url}/api/ProductAttributes/CreateTextAttribute`,
      JSON.stringify(productTextAtt), { headers: headers })
      .pipe( 
      tap((x)=>this.attrCreated.next(x)));

    return obs;
  }

  createChoiseAttribute(value: choiseAttribute): Observable<number> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    let obs = this.http.post<number>(`${this.url}/api/ProductAttributes/CreateChoiseAttribute`,
      JSON.stringify(value), { headers: headers })
      .pipe(tap(x => this.attrCreated.next(x)));
    return obs;
  }
}
