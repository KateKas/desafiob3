import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: 'calculo-cdb'
  },
  {
    path: 'calculo-cdb',
    loadChildren: () => import('./calculo-cdb/calculo-cdb.routes').then(r => r.calculocdb_Routes)
  }
];
