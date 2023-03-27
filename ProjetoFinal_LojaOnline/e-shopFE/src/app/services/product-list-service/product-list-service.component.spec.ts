import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductListServiceComponent } from './product-list-service.component';

describe('ProductListServiceComponent', () => {
  let component: ProductListServiceComponent;
  let fixture: ComponentFixture<ProductListServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductListServiceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductListServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
