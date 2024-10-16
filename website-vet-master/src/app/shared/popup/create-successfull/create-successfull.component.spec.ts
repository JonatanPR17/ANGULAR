import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateSuccessfullComponent } from './create-successfull.component';

describe('CreateSuccessfullComponent', () => {
  let component: CreateSuccessfullComponent;
  let fixture: ComponentFixture<CreateSuccessfullComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreateSuccessfullComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateSuccessfullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
