import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';
import { MessageComponent } from '../../Messages/Error/message/message.component';
import { UpdateMessageComponent } from '../../Messages/Success/Employee/update-message/update-message.component';

@Component({
  selector: 'app-employee-actualizar',
  templateUrl: './employee-actualizar.component.html',
  styleUrls: ['./employee-actualizar.component.css'],
})
export class EmployeeActualizarComponent {
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
    private activatedRoute: ActivatedRoute,
    private _snackBar: MatSnackBar
  ) {
    this.formulario = this.fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Title: ['', Validators.required],
      Country: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.mostrarForm();
  }

  ngOnDestroy(): void {
    this.suscripcion.unsubscribe();
  }

  guardar() {
    if (this.formulario.valid) {
      this.empleado = this.formulario.value;
      this.suscripcion.add(
        this.employeeService.putEmpleado(this.empleado).subscribe({
          next: () => {
            this.router.navigate(['listadoEmpleados']);
            this.openSnackBarSuccess();
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
    this._snackBar.openFromComponent(UpdateMessageComponent, {
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

  mostrarForm() {
    this.activatedRoute.params.subscribe({
      next: (params) => {
        const id = params['id'];

        if (id) {
          this.employeeService.getEmpleadoID(id).subscribe({
            next: (e: any) => {
              console.log(e.FirstName);
              this.empleado = e;
              this.formulario = this.fb.group({
                EmployeeID: [e.EmployeeID],
                FirstName: [e.FirstName, Validators.required],
                LastName: [e.LastName, Validators.required],
                Title: [e.Title, Validators.required],
                Country: [e.Country, Validators.required],
              });
            },
            error: () => {},
          });
        }
      },
      error: () => {},
    });
  }
}
