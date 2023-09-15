import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-employee-alta',
  templateUrl: './employee-alta.component.html',
  styleUrls: ['./employee-alta.component.css'],
})
export class EmployeeAltaComponent {
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
            this.router.navigate(['listadoEmpleados']);
          },
          error: () => {
            alert('ERROR postEmpleado()');
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
}
