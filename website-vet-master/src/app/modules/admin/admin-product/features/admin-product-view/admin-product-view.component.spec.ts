import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminProductViewComponent } from './admin-product-view.component';

describe('AdminProductViewComponent', () => {
  let component: AdminProductViewComponent;
  let fixture: ComponentFixture<AdminProductViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdminProductViewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminProductViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
