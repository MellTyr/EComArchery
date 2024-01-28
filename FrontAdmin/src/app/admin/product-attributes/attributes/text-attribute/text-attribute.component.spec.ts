import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TextAttributeComponent } from './text-attribute.component';

describe('TextAttributeComponent', () => {
  let component: TextAttributeComponent;
  let fixture: ComponentFixture<TextAttributeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TextAttributeComponent]
    });
    fixture = TestBed.createComponent(TextAttributeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
