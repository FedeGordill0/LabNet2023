import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeAltaComponent } from './employee-alta.component';

describe('EmployeeAltaComponent', () => {
  let component: EmployeeAltaComponent;
  let fixture: ComponentFixture<EmployeeAltaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeAltaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeAltaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
