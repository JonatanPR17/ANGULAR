import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PanelContactComponent } from './panel-contact.component';

describe('PanelContactComponent', () => {
  let component: PanelContactComponent;
  let fixture: ComponentFixture<PanelContactComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PanelContactComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PanelContactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
