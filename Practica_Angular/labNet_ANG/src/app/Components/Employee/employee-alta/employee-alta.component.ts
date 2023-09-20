import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';
import { InsertMessageComponent } from '../../Messages/Success/Employee/insert-message/insert-message.component';
import { MessageComponent } from '../../Messages/Error/message/message.component';

@Component({
  selector: 'app-employee-alta',
  templateUrl: './employee-alta.component.html',
  styleUrls: ['./employee-alta.component.css'],
})
export class EmployeeAltaComponent {
  private suscripcion = new Subscription();
  formulario: FormGroup;
  empleado: Employee;
  validarNombre: any;
  validarApellido: any;
  validarCargo: any;
  validarPais: any;

  constructor(
    private employeeService: EmployeeService,
    private router: Router,
    private fb: FormBuilder,
    private _snackBar: MatSnackBar
  ) {
    this.formulario = this.fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Title: ['', Validators.required],
      Country: ['', Validators.required],
    });
  }

  ngOnInit(): void {}

  ngOnDestroy(): void {
    this.suscripcion.unsubscribe();
  }

  guardar() {
    if (this.formulario.valid) {
      this.empleado = this.formulario.value;
      this.suscripcion.add(
        this.employeeService.postEmpleado(this.empleado).subscribe({
          next: () => {
            this.openSnackBarSuccess();
            this.router.navigate(['listadoEmpleados']);
          },
          error: () => {
            this.validarNombre = false;
            this.validarApellido = false;
            this.validarCargo = false;
            this.validarPais = false;

            if (this.formulario.value.FirstName.length > 10) {
              this.validarNombre = true;
            } else if (this.formulario.value.LastName.length > 20) {
              this.validarApellido = true;
            } else if (this.formulario.value.Title.length > 20) {
              this.validarCargo = true;
            } else if (this.formulario.value.Country.length > 20) {
              this.validarPais = true;
            }
          },
        })
      );
    } else {
      this.openSnackBarError();
    }
  }
  openSnackBarSuccess() {
    this._snackBar.openFromComponent(InsertMessageComponent, {
      duration: 1 * 1000,
    });
  }

  openSnackBarError() {
    this._snackBar.openFromComponent(MessageComponent, {
      duration: 1 * 1000,
    });
  }

  cancelar() {
    this.router.navigate(['listadoEmpleados']);
  }
}
