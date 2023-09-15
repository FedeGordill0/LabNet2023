import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryListadoComponent } from './category-listado.component';

describe('CategoryListadoComponent', () => {
  let component: CategoryListadoComponent;
  let fixture: ComponentFixture<CategoryListadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryListadoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CategoryListadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
