import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminBrandDetailComponent } from './admin-brand-detail.component';

describe('AdminBrandDetailComponent', () => {
  let component: AdminBrandDetailComponent;
  let fixture: ComponentFixture<AdminBrandDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdminBrandDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminBrandDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
