import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';
import { ServerComponent } from '../../Messages/Error/server/server.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-employee-listado',
  templateUrl: './employee-listado.component.html',
  styleUrls: ['./employee-listado.component.css'],
})
export class EmployeeListadoComponent {
  private suscripcion = new Subscription();
  listadoEmpleados: any = [];
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
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private employeeService: EmployeeService,
    private router: Router,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.actualizarListado();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  actualizarListado() {
    this.suscripcion.add(
      this.employeeService.getEmpleados().subscribe({
        next: (listado: any) => {
          this.dataSource.data = listado;
        },
        error: () => {
          this.openSnackBarErrorServer();
        },
      })
    );
  }
  filtro(e: Event) {
    const valorFiltro = (e.target as HTMLInputElement).value;
    this.dataSource.filter = valorFiltro.trim().toLowerCase();
  }

  openSnackBarErrorServer() {
    this._snackBar.openFromComponent(ServerComponent, {
      duration: 1 * 2500,
    });
  }

  irNuevoEmpleado() {
    this.router.navigate(['altaEmpleado']);
  }
  ngOnDestroy(): void {
    this.suscripcion.unsubscribe();
  }
}
