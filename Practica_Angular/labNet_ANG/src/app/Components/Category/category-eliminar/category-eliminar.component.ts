import {
  Component,
  EventEmitter,
  Input,
  OnDestroy,
  OnInit,
  Output,
} from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/Models/category';
import { CategoryService } from 'src/app/Services/category.service';
import { MessageComponent } from '../../Messages/Error/message/message.component';
import { DeleteMessageComponent } from '../../Messages/Success/Category/delete-message/delete-message.component';
import { MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-category-eliminar',
  templateUrl: './category-eliminar.component.html',
  styleUrls: ['./category-eliminar.component.css'],
})
export class CategoryEliminarComponent implements OnInit, OnDestroy {
  private suscripcion = new Subscription();
  @Input() categoria: Category;
  @Output() onEliminar = new EventEmitter();

  constructor(
    private categoryService: CategoryService,
    private _snackBar: MatSnackBar,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {}

  eliminarCategoria() {
    Swal.fire({
      title: 'Está seguro que quiere eliminar este registro?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si',
    }).then((result) => {
      if (result.isConfirmed) {
        this.suscripcion.add(
          this.categoryService.deleteCategoria(this.categoria).subscribe({
            next: () => {
              this.openSnackBarSuccess();
              this.onEliminar.emit();
            },
            error: () => {
              this.openSnackBarError();
            },
          })
        );
      }
    });
  }
  openSnackBarSuccess() {
    this._snackBar.openFromComponent(DeleteMessageComponent, {
      duration: 1 * 1000,
    });
  }

  openSnackBarError() {
    this._snackBar.openFromComponent(MessageComponent, {
      duration: 1 * 1000,
    });
  }
  ngOnDestroy(): void {
    this.suscripcion.unsubscribe();
  }
}
