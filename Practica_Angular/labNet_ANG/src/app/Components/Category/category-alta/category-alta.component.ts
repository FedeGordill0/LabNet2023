import {
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Route, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/Models/category';
import { CategoryService } from 'src/app/Services/category.service';
import { MessageComponent } from '../../Messages/Error/message/message.component';
import { InsertMessageComponent } from '../../Messages/Success/Category/insert-message/insert-message.component';

@Component({
  selector: 'app-category-alta',
  templateUrl: './category-alta.component.html',
  styleUrls: ['./category-alta.component.css'],
})
export class CategoryAltaComponent implements OnInit, OnDestroy {
  private suscripcion = new Subscription();
  formulario: FormGroup;
  categoria: Category;
  @ViewChild('divValidacion') divValidacion: ElementRef;

  constructor(
    private categoryService: CategoryService,
    private router: Router,
    private fb: FormBuilder,
    private _snackBar: MatSnackBar
  ) {
    this.formulario = this.fb.group({
      CategoryName: ['', Validators.required],
      Description: [''],
    });
  }

  ngOnInit(): void {}

  ngOnDestroy(): void {
    this.suscripcion.unsubscribe();
  }

  guardar() {
    console.log('this.formulario.value');
    if (this.formulario.valid) {
      this.categoria = this.formulario.value;
      this.suscripcion.add(
        this.categoryService.postCategoria(this.categoria).subscribe({
          next: () => {
            this.openSnackBarSuccess();
            this.router.navigate(['listadoCategorias']);
          },
          error: () => {
            if (this.formulario.value.CategoryName.length > 15) {
              this.divValidacion.nativeElement.style.display = '';
            }
          },
        })
      );
    } else {
      this.openSnackBarError();
    }
  }

  openSnackBarSuccess() {
    this._snackBar.openFromComponent(InsertMessageComponent, {
      duration: 1 * 1000,
    });
  }

  openSnackBarError() {
    this._snackBar.openFromComponent(MessageComponent, {
      duration: 1 * 1000,
    });
  }

  cancelar() {
    this.router.navigate(['listadoCategorias']);
  }
}
