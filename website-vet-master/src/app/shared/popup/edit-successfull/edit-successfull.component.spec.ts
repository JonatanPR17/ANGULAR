import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditSuccessfullComponent } from './edit-successfull.component';

describe('EditSuccessfullComponent', () => {
  let component: EditSuccessfullComponent;
  let fixture: ComponentFixture<EditSuccessfullComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditSuccessfullComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditSuccessfullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
