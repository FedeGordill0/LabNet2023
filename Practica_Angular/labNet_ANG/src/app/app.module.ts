import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeAltaComponent } from './Components/Employee/employee-alta/employee-alta.component';
import { EmployeeListadoComponent } from './Components/Employee/employee-listado/employee-listado.component';
import { EmployeeActualizarComponent } from './Components/Employee/employee-actualizar/employee-actualizar.component';
import { EmployeeEliminarComponent } from './Components/Employee/employee-eliminar/employee-eliminar.component';
import { CategoryEliminarComponent } from './Components/Category/category-eliminar/category-eliminar.component';
import { CategoryListadoComponent } from './Components/Category/category-listado/category-listado.component';
import { CategoryAltaComponent } from './Components/Category/category-alta/category-alta.component';
import { CategoryActualizarComponent } from './Components/Category/category-actualizar/category-actualizar.component';
import { CategoryService } from './Services/category.service';
import { EmployeeService } from './Services/employee.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatPaginatorModule } from '@angular/material/paginator';
import { DashboardComponent } from './Components/Home/dashboard/dashboard.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
@NgModule({
  declarations: [
    AppComponent,
    EmployeeAltaComponent,
    EmployeeListadoComponent,
    EmployeeActualizarComponent,
    EmployeeEliminarComponent,
    CategoryEliminarComponent,
    CategoryListadoComponent,
    CategoryAltaComponent,
    CategoryActualizarComponent,
    DashboardComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatCardModule,
    MatInputModule,
    MatPaginatorModule,
    MatToolbarModule,
    MatSidenavModule,
  ],
  providers: [CategoryService, EmployeeService],
  bootstrap: [AppComponent],
})
export class AppModule {}
