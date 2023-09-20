import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeAltaComponent } from './Components/Employee/employee-alta/employee-alta.component';
import { EmployeeListadoComponent } from './Components/Employee/employee-listado/employee-listado.component';
import { EmployeeActualizarComponent } from './Components/Employee/employee-actualizar/employee-actualizar.component';
import { EmployeeEliminarComponent } from './Components/Employee/employee-eliminar/employee-eliminar.component';
import { CategoryEliminarComponent } from './Components/Category/category-eliminar/category-eliminar.component';
import {
  CategoryListadoComponent,
  CustomPaginatorIntl,
} from './Components/Category/category-listado/category-listado.component';
import { CategoryAltaComponent } from './Components/Category/category-alta/category-alta.component';
import { CategoryActualizarComponent } from './Components/Category/category-actualizar/category-actualizar.component';
import { CategoryService } from './Services/category.service';
import { EmployeeService } from './Services/employee.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DeleteMessageComponent } from './Components/Messages/Success/Category/delete-message/delete-message.component';
import { DashboardComponent } from './Components/Home/dashboard/dashboard.component';
import { InsertMessageComponent } from './Components/Messages/Success/Category/insert-message/insert-message.component';
import { UpdateMessageComponent } from './Components/Messages/Success/Category/update-message/update-message.component';
import { ServerComponent } from './Components/Messages/Error/server/server.component';
import { SharedModule } from './Components/shared/shared.module';

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
    InsertMessageComponent,
    UpdateMessageComponent,
    DeleteMessageComponent,
    ServerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    SharedModule,
  ],
  providers: [CategoryService, EmployeeService],
  bootstrap: [AppComponent],
})
export class AppModule {}
