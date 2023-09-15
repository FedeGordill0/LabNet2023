import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryActualizarComponent } from './category-actualizar.component';

describe('CategoryActualizarComponent', () => {
  let component: CategoryActualizarComponent;
  let fixture: ComponentFixture<CategoryActualizarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryActualizarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CategoryActualizarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
