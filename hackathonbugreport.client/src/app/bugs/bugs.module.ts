import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { BugsComponent } from './bugs.component';
import { BugComponent } from './bug/bug.component';


const routes: Routes = [
  {
    path: '',
    component: BugsComponent,
  },
  {
    path: ':id',
    component: BugComponent,
  },
];

@NgModule({
  declarations: [BugsComponent, BugComponent],
  imports: [RouterModule.forChild(routes), SharedModule],
})
export class BugsModule {}
