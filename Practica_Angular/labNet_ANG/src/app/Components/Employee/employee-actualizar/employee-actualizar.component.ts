import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription } from 'rxjs';
import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-employee-actualizar',
  templateUrl: './employee-actualizar.component.html',
  styleUrls: ['./employee-actualizar.component.css'],
})
export class EmployeeActualizarComponent {
  private suscripcion = new Subscription();
  formulario: FormGroup;
  empleado: Employee;
  constructor(
    private employeeService: EmployeeService,
    private router: Router,
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute
  ) {
    this.formulario = this.fb.group({
      FirstName: ['', Validators.required, Validators.maxLength(10)],
      LastName: ['', Validators.required, Validators.maxLength(20)],
      Title: ['', Validators.required, Validators.maxLength(30)],
      Country: ['', Validators.required, Validators.maxLength(15)],
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
          },
          error: () => {
            alert('ERROR putEmpleado()');
          },
        })
      );
    } else {
      alert('error de formulario');
    }
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
                FirstName: [e.FirstName],
                LastName: [e.LastName],
                Title: [e.Title],
                Country: [e.Country],
              });
            },
            error: () => {
              alert('ERROR employeeService.getEmpleadoID');
            },
          });
        }
      },
      error: () => {
        alert('error activatedRoute');
      },
    });
  }
}
