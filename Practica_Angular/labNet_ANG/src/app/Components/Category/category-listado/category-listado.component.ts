import {
  AfterViewInit,
  Component,
  Injectable,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/Models/category';
import { CategoryService } from 'src/app/Services/category.service';
import { ServerComponent } from '../../Messages/Error/server/server.component';
import { MatSnackBar } from '@angular/material/snack-bar';

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
  dataSource = new MatTableDataSource<any>(this.listadoCategorias);

  displayedColumns: string[] = ['CategoryName', 'Description', 'Acciones', 'a'];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private categoryService: CategoryService,
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
      this.categoryService.getCategorias().subscribe({
        next: (listado: any) => {
          this.dataSource.data = listado;
        },
        error: () => {
          this.openSnackBarErrorServer();
        },
      })
    );
  }
  irNuevaCategoria() {
    this.router.navigate(['altaCategoria']);
  }

  filtro(e: Event) {
    const valorFiltro = (e.target as HTMLInputElement).value;
    this.dataSource.filter = valorFiltro.trim().toLowerCase();
  }

  sortData(e: Event) {}

  openSnackBarErrorServer() {
    this._snackBar.openFromComponent(ServerComponent, {
      duration: 1 * 2500,
    });
  }

  ngOnDestroy(): void {
    this.suscripcion.unsubscribe();
  }
}
@Injectable()
export class CustomPaginatorIntl extends MatPaginatorIntl {
  override itemsPerPageLabel = 'Items por página:';
}
