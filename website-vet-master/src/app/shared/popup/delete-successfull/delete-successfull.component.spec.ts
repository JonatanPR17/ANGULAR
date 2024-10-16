import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteSuccessfullComponent } from './delete-successfull.component';

describe('DeleteSuccessfullComponent', () => {
  let component: DeleteSuccessfullComponent;
  let fixture: ComponentFixture<DeleteSuccessfullComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeleteSuccessfullComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteSuccessfullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
