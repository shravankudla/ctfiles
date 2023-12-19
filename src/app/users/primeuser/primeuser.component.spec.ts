import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrimeuserComponent } from './primeuser.component';

describe('PrimeuserComponent', () => {
  let component: PrimeuserComponent;
  let fixture: ComponentFixture<PrimeuserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrimeuserComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrimeuserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
