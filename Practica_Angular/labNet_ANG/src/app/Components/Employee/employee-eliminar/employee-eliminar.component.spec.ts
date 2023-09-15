import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeEliminarComponent } from './employee-eliminar.component';

describe('EmployeeEliminarComponent', () => {
  let component: EmployeeEliminarComponent;
  let fixture: ComponentFixture<EmployeeEliminarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeEliminarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeEliminarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
