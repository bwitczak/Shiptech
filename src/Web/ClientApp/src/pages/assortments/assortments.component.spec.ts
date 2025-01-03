import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssortmentsComponent } from './assortments.component';

describe('AssortmentsComponent', () => {
  let component: AssortmentsComponent;
  let fixture: ComponentFixture<AssortmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AssortmentsComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(AssortmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
