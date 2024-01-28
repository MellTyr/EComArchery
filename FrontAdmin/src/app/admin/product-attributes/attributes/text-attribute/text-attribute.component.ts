import { Component, Input } from '@angular/core';
import { TextAttribute } from 'src/app/admin/Models/productAttribute';

@Component({
  selector: 'app-text-attribute',
  templateUrl: './text-attribute.component.html',
  styleUrls: ['./text-attribute.component.css']
})
export class TextAttributeComponent {
  @Input() productTextAttribute!: TextAttribute
}
