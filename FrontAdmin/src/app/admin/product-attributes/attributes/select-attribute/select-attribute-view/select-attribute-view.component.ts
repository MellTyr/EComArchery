import { Component, Input } from '@angular/core';
import { choiseAttribute } from 'src/app/admin/Models/productAttribute';

@Component({
  selector: 'app-select-attribute-view',
  templateUrl: './select-attribute-view.component.html',
  styleUrl: './select-attribute-view.component.css'
})
export class SelectAttributeViewComponent {
  @Input() productChoiseAttribute!: choiseAttribute
}
