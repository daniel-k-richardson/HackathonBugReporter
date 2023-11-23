import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { BugsComponent } from './bugs.component';


const routes: Routes = [
  {
    path: '',
    component: BugsComponent,
  },
];

@NgModule({
  declarations: [BugsComponent],
  imports: [RouterModule.forChild(routes), SharedModule],
})
export class BugsModule {}
