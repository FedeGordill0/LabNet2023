import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';
import { DeleteMessageComponent } from '../../Messages/Success/Employee/delete-message/delete-message.component';
import { MessageComponent } from '../../Messages/Error/message/message.component';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-employee-eliminar',
  templateUrl: './employee-eliminar.component.html',
  styleUrls: ['./employee-eliminar.component.css'],
})
export class EmployeeEliminarComponent {
  private suscripcion = new Subscription();
  @Input() empleado: Employee;
  @Output() onEliminar = new EventEmitter();
  constructor(
    private employeeService: EmployeeService,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {}

  eliminarEmpleado() {
    Swal.fire({
      title: 'Está seguro que quiere eliminar este registro?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si',
    }).then((result) => {
      if (result.isConfirmed) {
        this.suscripcion.add(
          this.employeeService.deleteEmpleado(this.empleado).subscribe({
            next: () => {
              this.openSnackBarSuccess();
              this.onEliminar.emit();
            },
            error: () => {
              this.openSnackBarError();
            },
          })
        );
      }
    });
  }
  openSnackBarSuccess() {
    this._snackBar.openFromComponent(DeleteMessageComponent, {
      duration: 1 * 1000,
    });
  }

  openSnackBarError() {
    this._snackBar.openFromComponent(MessageComponent, {
      duration: 1 * 1000,
    });
  }

  ngOnDestroy(): void {
    this.suscripcion.unsubscribe();
  }
}
