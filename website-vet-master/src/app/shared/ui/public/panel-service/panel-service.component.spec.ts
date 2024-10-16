import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PanelServiceComponent } from './panel-service.component';

describe('PanelServiceComponent', () => {
  let component: PanelServiceComponent;
  let fixture: ComponentFixture<PanelServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PanelServiceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PanelServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
