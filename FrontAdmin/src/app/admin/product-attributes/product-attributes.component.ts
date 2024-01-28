import { Component, inject } from '@angular/core';
import { AttributeService } from '../attribute.service';
import { attributeType, choiseAttribute, TextAttribute } from '../Models/productAttribute';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ProductService } from '../product.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { tap } from 'rxjs';

@Component({
  selector: 'app-product-attributes',
  templateUrl: './product-attributes.component.html',
  styleUrls: ['./product-attributes.component.css'],
})
export class ProductAttributesComponent {
  attributeService: AttributeService = inject(AttributeService);
  productService: ProductService = inject(ProductService);
  textAttrList: TextAttribute[] = [];
  choiseAttrList: choiseAttribute[] = [];

  _snackBar: MatSnackBar = inject(MatSnackBar);

  applyForm = new FormGroup({
    name: new FormControl('')
  });

  selectedAttrType: number|undefined;

  selectedTypeChanged(value: string) {
    let _value = parseInt(value);
    if (_value === attributeType.choise) {
      this.selectedAttrType = attributeType.choise;
    }
    else {
      this.selectedAttrType = attributeType.text;
    }
  };

  constructor() {
    this.attributeService.getProductTextAttributes().subscribe(x => this.textAttrList = x);
    this.productService.productCreated
      .subscribe(x => this.attributeService.getProductTextAttributes().subscribe(w => this.textAttrList = w));
      this.attributeService.getChoiseAttributes().subscribe(w=>this.choiseAttrList=w);

      this.attributeService.attrCreated.subscribe(x=>{
        this.attributeService.getChoiseAttributes().subscribe(w=>{
          debugger;
          this.choiseAttrList=w;
        });
        this.attributeService.getProductTextAttributes().subscribe(x => this.textAttrList = x);
      });
  }

  createTextAttr(): void {
    this.attributeService.createTextAttribute({
      attributeType: attributeType.text,
      id: 0,
      name: this.applyForm.value.name ?? ''
    })
      .pipe(tap(x => this._snackBar.open(`Текстовый аттрибут создан, id=${x}`, undefined, { duration: 1000 })))
      .subscribe();
  }
}
