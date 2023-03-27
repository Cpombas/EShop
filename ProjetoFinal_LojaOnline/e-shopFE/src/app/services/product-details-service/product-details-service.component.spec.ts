import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDetailsServiceComponent } from './product-details-service.component';

describe('ProductDetailsServiceComponent', () => {
  let component: ProductDetailsServiceComponent;
  let fixture: ComponentFixture<ProductDetailsServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductDetailsServiceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductDetailsServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
