import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeActualizarComponent } from './employee-actualizar.component';

describe('EmployeeActualizarComponent', () => {
  let component: EmployeeActualizarComponent;
  let fixture: ComponentFixture<EmployeeActualizarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeActualizarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeActualizarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
