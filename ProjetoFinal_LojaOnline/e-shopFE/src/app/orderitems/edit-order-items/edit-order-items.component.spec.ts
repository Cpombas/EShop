import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditOrderItemsComponent } from './edit-order-items.component';

describe('EditOrderItemsComponent', () => {
  let component: EditOrderItemsComponent;
  let fixture: ComponentFixture<EditOrderItemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditOrderItemsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditOrderItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});