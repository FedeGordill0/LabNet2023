import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-employee-eliminar',
  templateUrl: './employee-eliminar.component.html',
  styleUrls: ['./employee-eliminar.component.css'],
})
export class EmployeeEliminarComponent {
  private suscripcion = new Subscription();
  @Input() empleado: Employee;
  @Output() onEliminar = new EventEmitter();
  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {}

  eliminarEmpleado() {
    this.suscripcion.add(
      this.employeeService.deleteEmpleado(this.empleado).subscribe({
        next: () => {
          this.onEliminar.emit();
        },
        error: () => {
          alert('ERROR deleteEmpleado()');
        },
      })
    );
  }

  ngOnDestroy(): void {
    this.suscripcion.unsubscribe();
  }
}
