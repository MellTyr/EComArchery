import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectAttributeCreateComponent } from './select-attribute-create.component';

describe('SelectAttributeCreateComponent', () => {
  let component: SelectAttributeCreateComponent;
  let fixture: ComponentFixture<SelectAttributeCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SelectAttributeCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SelectAttributeCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
