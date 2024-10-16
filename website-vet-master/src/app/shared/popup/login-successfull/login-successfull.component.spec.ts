import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginSuccessfullComponent } from './login-successfull.component';

describe('LoginSuccessfullComponent', () => {
  let component: LoginSuccessfullComponent;
  let fixture: ComponentFixture<LoginSuccessfullComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LoginSuccessfullComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginSuccessfullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
