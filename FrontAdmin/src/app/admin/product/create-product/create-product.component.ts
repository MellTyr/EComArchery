import { Component, Input, inject } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Product } from '../../Models/product';
import { ProductTextAttribute, TextAttribute, attributeType } from '../../Models/productAttribute';
import { ProductService } from '../../product.service';
import { tap } from 'rxjs';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css'],
})
export class CreateProductComponent {
  @Input() availableTextAttributes: TextAttribute[] = [];
  productService: ProductService = inject(ProductService);
  fb: FormBuilder = inject(FormBuilder);
  _snackBar: MatSnackBar = inject(MatSnackBar);

  productForm: FormGroup = this.initialize();

  private createTextAttribute(): FormGroup {
    return this.fb.group({
      id: new FormControl<number>(0),
      name: new FormControl(''),
      value: new FormControl('')
    });
  }

  initialize():FormGroup{
    return this.fb.group(
      {
        productName: new FormControl(''),
        textAttrubutes: this.fb.array([])
      }); 
  }

  createProduct() {
    let form = this.productForm.value;
    let product: Product =
    {
      id: 0,
      name: form.productName,
      textAttributeVMs: form.textAttrubutes.map((a: any) => {
        return <ProductTextAttribute>{
          id: a.id, name: a.name, attributeType: attributeType.text,
          value: { id: 0, text: a.value }
        }
      })
    };
    this.productService.createProduct(product)
      .pipe(tap(x=>this._snackBar.open(`Продукт создан, id=${x}`,undefined,{ duration : 1000})))
      .subscribe(x => this.productForm = this.initialize());
  }

  addTextAttribute() {
    const textAttr = this.getTextAttributeControls;
    textAttr.push(this.createTextAttribute())
  }
  deleteTextAttribute(index: number) {
    const textAttr = this.getTextAttributeControls;
    textAttr.removeAt(index);
  }

  get getTextAttributeControls() {
    return this.productForm.get('textAttrubutes') as FormArray;
  }
}
