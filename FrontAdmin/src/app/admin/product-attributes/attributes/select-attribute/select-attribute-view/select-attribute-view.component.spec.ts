import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectAttributeViewComponent } from './select-attribute-view.component';

describe('SelectAttributeViewComponent', () => {
  let component: SelectAttributeViewComponent;
  let fixture: ComponentFixture<SelectAttributeViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SelectAttributeViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SelectAttributeViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
