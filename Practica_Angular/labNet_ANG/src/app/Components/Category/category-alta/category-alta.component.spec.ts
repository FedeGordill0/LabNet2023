import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryAltaComponent } from './category-alta.component';

describe('CategoryAltaComponent', () => {
  let component: CategoryAltaComponent;
  let fixture: ComponentFixture<CategoryAltaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryAltaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CategoryAltaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
