import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { CabtypesComponent } from './core/cabtypes/cabtypes.component';
import { HomeComponent } from './home/home.component';
import { PlacesComponent } from './core/places/places.component';
import { BookinghistoriesComponent } from './core/bookinghistories/bookinghistories.component';
import { BookingsComponent } from './core/bookings/bookings.component';
import { CabtypeDetailsComponent } from './core/cabtypes/cabtype-details/cabtype-details.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    CabtypesComponent,
    HomeComponent,
    PlacesComponent,
    BookinghistoriesComponent,
    BookingsComponent,
    CabtypeDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
