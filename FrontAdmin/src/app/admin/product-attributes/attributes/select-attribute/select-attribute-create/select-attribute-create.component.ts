import { Component, inject } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { tap } from 'rxjs';
import { choiseAttribute } from 'src/app/admin/Models/productAttribute';
import { AttributeService } from 'src/app/admin/attribute.service';

@Component({
  selector: 'app-select-attribute-create',
  standalone: false,
  templateUrl: './select-attribute-create.component.html',
  styleUrl: './select-attribute-create.component.css'
})
export class SelectAttributeCreateComponent {

  fb: FormBuilder = inject(FormBuilder);
  attributeService: AttributeService = inject(AttributeService);
  _snackBar: MatSnackBar = inject(MatSnackBar);

  attributeForm: FormGroup = this.Initialize();

  Initialize(): FormGroup {
    return this.fb.group({
      attributeName: new FormControl(''),
      choises: this.fb.array([])
    });
  }

  addChoiseValue() {
    const choises = this.getChoises;
    choises.push(this.createChoiseValue());
  }

  private createChoiseValue(): FormGroup {
    return this.fb.group(
      {
        value: new FormControl('')
      });
  }

  get getChoises() {
    return this.attributeForm.get('choises') as FormArray
  }

  createAttribute() {
    const form = this.attributeForm.value;
    let choiseAttr: choiseAttribute = {
      id: 0,
      name: form.attributeName,
      values: form.choises.map((c: any) => {
        return {
          value: c.value,
          id: 0}
      }
      )
    }
    this.attributeService.createChoiseAttribute(choiseAttr)
      .pipe(tap(x => this._snackBar.open(`Аттрибут выбора создан, id=${x}`, undefined, { duration: 1000 })))
      .subscribe(x => this.attributeForm = this.Initialize());
  }
}
