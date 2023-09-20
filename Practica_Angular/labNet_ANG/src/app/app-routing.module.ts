import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryListadoComponent } from './Components/Category/category-listado/category-listado.component';
import { CategoryActualizarComponent } from './Components/Category/category-actualizar/category-actualizar.component';
import { CategoryAltaComponent } from './Components/Category/category-alta/category-alta.component';
import { EmployeeListadoComponent } from './Components/Employee/employee-listado/employee-listado.component';
import { EmployeeAltaComponent } from './Components/Employee/employee-alta/employee-alta.component';
import { EmployeeActualizarComponent } from './Components/Employee/employee-actualizar/employee-actualizar.component';
import { DashboardComponent } from './Components/Home/dashboard/dashboard.component';
//cambiar nombre ruta empleadp
const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'listadoCategorias', component: CategoryListadoComponent },
  { path: 'altaCategoria', component: CategoryAltaComponent },
  { path: 'modificarCategoria/:id', component: CategoryActualizarComponent },
  { path: 'listadoEmpleados', component: EmployeeListadoComponent },
  { path: 'altaEmpleado', component: EmployeeAltaComponent },
  { path: 'modificarEmpleado/:id', component: EmployeeActualizarComponent },
  { path: '**', redirectTo: 'dashboard' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
