import { Routes } from '@angular/router';
import { DrawingsComponent } from '../pages/drawings/drawings.component';
import { IsosComponent } from '../pages/isos/isos.component';
import { AssortmentsComponent } from '../pages/assortments/assortments.component';

export const routes: Routes = [
  { path: 'drawings/:shipCode', component: DrawingsComponent },
  { path: 'isos/:drawingNumber', component: IsosComponent },
  { path: 'assortments/:isoNumber', component: AssortmentsComponent },
];
