import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditOrderProductComponent } from './edit-order-product.component';

describe('EditOrderProductComponent', () => {
  let component: EditOrderProductComponent;
  let fixture: ComponentFixture<EditOrderProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditOrderProductComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditOrderProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
