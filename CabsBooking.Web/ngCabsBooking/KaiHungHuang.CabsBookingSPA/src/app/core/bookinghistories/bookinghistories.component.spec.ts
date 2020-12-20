import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookinghistoriesComponent } from './bookinghistories.component';

describe('BookinghistoriesComponent', () => {
  let component: BookinghistoriesComponent;
  let fixture: ComponentFixture<BookinghistoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookinghistoriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookinghistoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
