import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentDetailsServiceComponent } from './payment-details-service.component';

describe('PaymentDetailsServiceComponent', () => {
  let component: PaymentDetailsServiceComponent;
  let fixture: ComponentFixture<PaymentDetailsServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaymentDetailsServiceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PaymentDetailsServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
