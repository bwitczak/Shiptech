import { Routes } from '@angular/router';
import { DrawingsComponent } from '../pages/drawings/drawings.component';
import { IsosComponent } from '../pages/isos/isos.component';

export const routes: Routes = [
  { path: 'drawings/:shipCode', component: DrawingsComponent },
  { path: 'isos/:drawingNumber', component: IsosComponent },
];
