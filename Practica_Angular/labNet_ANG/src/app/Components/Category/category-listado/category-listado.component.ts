import {
  AfterViewInit,
  Component,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/Models/category';
import { CategoryService } from 'src/app/Services/category.service';

@Component({
  selector: 'app-category-listado',
  templateUrl: './category-listado.component.html',
  styleUrls: ['./category-listado.component.css'],
})
export class CategoryListadoComponent
  implements OnInit, OnDestroy, AfterViewInit
{
  private suscripcion = new Subscription();
  listadoCategorias: any = [];
  // dataSource = new MatTableDataSource(this.listadoCategorias);
  dataSource = new MatTableDataSource<any>(this.listadoCategorias);

  displayedColumns: string[] = ['CategoryName', 'Description', 'Acciones', 'a'];
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private categoryService: CategoryService,
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
      this.categoryService.getCategorias().subscribe({
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
  irNuevaCategoria() {
    this.router.navigate(['altaCategoria']);
  }
  ngOnDestroy(): void {
    this.suscripcion.unsubscribe();
  }
}
