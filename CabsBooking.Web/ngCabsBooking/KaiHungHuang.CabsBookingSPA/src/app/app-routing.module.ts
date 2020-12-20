import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookinghistoriesComponent } from './core/bookinghistories/bookinghistories.component';
import { BookingsComponent } from './core/bookings/bookings.component';
import { CabtypeDetailsComponent } from './core/cabtypes/cabtype-details/cabtype-details.component';
import { CabtypesComponent } from './core/cabtypes/cabtypes.component';
import { PlacesComponent } from './core/places/places.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'cabtype',
    component: CabtypesComponent,
  },
  {
    path: 'place',
    component: PlacesComponent,
  },
  {
    path: 'bookinghistory',
    component: BookinghistoriesComponent,
  },
  {
    path: 'booking',
    component: BookingsComponent,
  },
  {
    path: 'booking/cabtype/:id',
    component: CabtypeDetailsComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
