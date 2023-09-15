import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/Models/category';
import { CategoryService } from 'src/app/Services/category.service';

@Component({
  selector: 'app-category-alta',
  templateUrl: './category-alta.component.html',
  styleUrls: ['./category-alta.component.css'],
})
export class CategoryAltaComponent implements OnInit, OnDestroy {
  private suscripcion = new Subscription();
  formulario: FormGroup;
  categoria: Category;
  constructor(
    private categoryService: CategoryService,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.formulario = this.fb.group({
      CategoryName: ['', Validators.required, Validators.maxLength(15)],
      Description: [''],
    });
  }

  ngOnInit(): void {}

  ngOnDestroy(): void {
    this.suscripcion.unsubscribe();
  }

  guardar() {
    if (this.formulario.valid) {
      this.categoria = this.formulario.value;
      this.suscripcion.add(
        this.categoryService.postCategoria(this.categoria).subscribe({
          next: () => {
            this.router.navigate(['listadoCategorias']);
          },
          error: () => {
            alert('ERROR postCategoria()');
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
}
