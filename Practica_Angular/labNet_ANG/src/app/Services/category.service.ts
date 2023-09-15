import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '../Models/category';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class CategoryService {
  api_url: string = environment.api_categorias_url;
  //https://localhost:44312/api/CategoryAPI
  constructor(private http: HttpClient) {}

  getCategorias(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.api_url}`);
  }
  getCategoriaID(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.api_url}/${id}`);
  }
  postCategoria(categoria: Category): Observable<Category> {
    return this.http.post<Category>(`${this.api_url}`, categoria);
  }
  deleteCategoria(categoria: Category): Observable<any> {
    return this.http.delete(`${this.api_url}/` + categoria.CategoryID);
  }
  putCategoria(categoria: Category): Observable<Category> {
    return this.http.put<Category>(
      `${this.api_url}/` + categoria.CategoryID,
      categoria
    );
  }
}
