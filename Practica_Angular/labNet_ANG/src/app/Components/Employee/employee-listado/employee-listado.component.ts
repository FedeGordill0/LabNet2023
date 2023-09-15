import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-employee-listado',
  templateUrl: './employee-listado.component.html',
  styleUrls: ['./employee-listado.component.css'],
})
export class EmployeeListadoComponent {
  private suscripcion = new Subscription();
  listadoEmpleados: any = [];
  // dataSource = new MatTableDataSource(this.listadoCategorias);
  dataSource = new MatTableDataSource<any>(this.listadoEmpleados);

  displayedColumns: string[] = [
    'FirstName',
    'LastName',
    'Title',
    'Country',
    'Acciones',
    'a',
  ];
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private employeeService: EmployeeService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.actualizarListado();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  actualizarListado() {
    this.suscripcion.add(
      this.employeeService.getEmpleados().subscribe({
        next: (listado: any) => {
          console.log(listado);
          // this.listadoCategorias = listado;
          this.dataSource.data = listado;
        },
        error: () => {
          alert('ERROR actualizarListado()');
        },
      })
    );
  }
  irNuevoEmpleado() {
    this.router.navigate(['altaEmpleado']);
  }
  ngOnDestroy(): void {
    this.suscripcion.unsubscribe();
  }
}
