import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';

import { Subscription } from 'rxjs';
import { Category } from 'src/app/Models/category';
import { CategoryService } from 'src/app/Services/category.service';
import { MessageComponent } from '../../Messages/Error/message/message.component';
import { UpdateMessageComponent } from '../../Messages/Success/Category/update-message/update-message.component';

@Component({
  selector: 'app-category-actualizar',
  templateUrl: './category-actualizar.component.html',
  styleUrls: ['./category-actualizar.component.css'],
})
export class CategoryActualizarComponent {
  private suscripcion = new Subscription();
  formulario: FormGroup;
  categoria: Category;
  @ViewChild('divValidacion') divValidacion: ElementRef;

  constructor(
    private categoryService: CategoryService,
    private router: Router,
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private _snackBar: MatSnackBar
  ) {
    this.formulario = this.fb.group({
      CategoryName: ['', Validators.required],
      Description: [''],
    });
  }

  ngOnInit(): void {
    this.mostrarForm();
  }

  ngOnDestroy(): void {
    this.suscripcion.unsubscribe();
  }

  guardar() {
    if (this.formulario.valid) {
      this.categoria = this.formulario.value;
      this.suscripcion.add(
        this.categoryService.putCategoria(this.categoria).subscribe({
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

  cancelar() {
    this.router.navigate(['listadoCategorias']);
  }

  openSnackBarSuccess() {
    this._snackBar.openFromComponent(UpdateMessageComponent, {
      duration: 1 * 1000,
    });
  }

  openSnackBarError() {
    this._snackBar.openFromComponent(MessageComponent, {
      duration: 1 * 1000,
    });
  }

  mostrarForm() {
    this.activatedRoute.params.subscribe({
      next: (params) => {
        const id = params['id'];

        if (id) {
          this.categoryService.getCategoriaID(id).subscribe({
            next: (c: any) => {
              this.categoria = c;
              this.formulario = this.fb.group({
                CategoryID: [c.CategoryID],
                CategoryName: [c.CategoryName, Validators.required],
                Description: [c.Description],
              });
            },
            error: () => {},
          });
        }
      },
      error: () => {},
    });
  }
}
