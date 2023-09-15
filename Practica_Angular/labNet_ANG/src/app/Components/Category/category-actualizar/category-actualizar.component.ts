import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Subscription } from 'rxjs';
import { Category } from 'src/app/Models/category';
import { CategoryService } from 'src/app/Services/category.service';

@Component({
  selector: 'app-category-actualizar',
  templateUrl: './category-actualizar.component.html',
  styleUrls: ['./category-actualizar.component.css'],
})
export class CategoryActualizarComponent {
  private suscripcion = new Subscription();
  formulario: FormGroup;
  categoria: Category;
  constructor(
    private categoryService: CategoryService,
    private router: Router,
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute
  ) {
    this.formulario = this.fb.group({
      CategoryName: ['', Validators.required, Validators.maxLength(15)],
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
            this.router.navigate(['listadoCategorias']);
          },
          error: () => {
            alert('ERROR puttCategoria()');
          },
        })
      );
    } else {
      alert('error de formulario');
    }
  }

  cancelar() {
    this.router.navigate(['listadoCategorias']);
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
                CategoryName: [c.CategoryName],
                Description: [c.Description],
              });
            },
            error: () => {
              alert('ERROR categoryService.getCategoria');
            },
          });
        }
      },
      error: () => {
        alert('error activatedRoute');
      },
    });
  }
}
