import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CabtypeDetailsComponent } from './cabtype-details.component';

describe('CabtypeDetailsComponent', () => {
  let component: CabtypeDetailsComponent;
  let fixture: ComponentFixture<CabtypeDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CabtypeDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CabtypeDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
