import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryEliminarComponent } from './category-eliminar.component';

describe('CategoryEliminarComponent', () => {
  let component: CategoryEliminarComponent;
  let fixture: ComponentFixture<CategoryEliminarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryEliminarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CategoryEliminarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
