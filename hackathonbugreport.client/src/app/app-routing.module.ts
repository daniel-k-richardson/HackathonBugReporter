import { NgModule, inject } from '@angular/core';
import { PreloadAllModules, Router, RouterModule, RouterStateSnapshot, Routes } from '@angular/router';
import { AuthService } from './auth.service';
import { LoginComponent } from './core/login/login.component';

const authGuard = (_: any, state: RouterStateSnapshot) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  if (!authService.isLoggedIn()) {
    router.navigate(['login']);
    return false;
  }

  return true;
};

const routes: Routes = [
  {
    path: '',
    canActivate: [authGuard],
    children: [
      {
        path: '',
        pathMatch: 'full',
        loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
      },
      {
        path: 'bugs',
        loadChildren: () => import('./bugs/bugs.module').then(m => m.BugsModule)
      },
    ],
  },
  {
    path: 'login',
    pathMatch: 'full',
    component: LoginComponent
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      preloadingStrategy: PreloadAllModules
    }),
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
