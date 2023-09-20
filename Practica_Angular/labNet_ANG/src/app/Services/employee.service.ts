import { Injectable } from '@angular/core';
import { Employee } from '../Models/employee';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class EmployeeService {
  api_url: string = environment.api_empleados_url;
  //https://localhost:44312/api/EmployeeAPI
  constructor(private http: HttpClient) {}

  getEmpleados(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.api_url}`);
  }
  getEmpleadoID(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.api_url}/${id}`);
  }
  postEmpleado(empleado: Employee): Observable<Employee> {
    return this.http.post<Employee>(`${this.api_url}`, empleado);
  }
  deleteEmpleado(empleado: Employee): Observable<any> {
    return this.http.delete(`${this.api_url}/` + empleado.EmployeeID);
  }
  putEmpleado(empleado: Employee): Observable<Employee> {
    return this.http.put<Employee>(
      `${this.api_url}/` + empleado.EmployeeID,
      empleado
    );
  }
}
