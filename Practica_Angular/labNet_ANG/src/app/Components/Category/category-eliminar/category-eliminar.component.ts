import {
  Component,
  EventEmitter,
  Input,
  OnDestroy,
  OnInit,
  Output,
} from '@angular/core';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/Models/category';
import { CategoryService } from 'src/app/Services/category.service';

@Component({
  selector: 'app-category-eliminar',
  templateUrl: './category-eliminar.component.html',
  styleUrls: ['./category-eliminar.component.css'],
})
export class CategoryEliminarComponent implements OnInit, OnDestroy {
  private suscripcion = new Subscription();
  @Input() categoria: Category;
  @Output() onEliminar = new EventEmitter();
  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {}

  eliminarCategoria() {
    this.suscripcion.add(
      this.categoryService.deleteCategoria(this.categoria).subscribe({
        next: () => {
          this.onEliminar.emit();
        },
        error: () => {
          alert('ERROR eliminarCategoria()');
        },
      })
    );
  }

  ngOnDestroy(): void {
    this.suscripcion.unsubscribe();
  }
}
