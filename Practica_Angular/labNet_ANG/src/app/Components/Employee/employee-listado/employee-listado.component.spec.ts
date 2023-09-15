import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeListadoComponent } from './employee-listado.component';

describe('EmployeeListadoComponent', () => {
  let component: EmployeeListadoComponent;
  let fixture: ComponentFixture<EmployeeListadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeListadoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeListadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
