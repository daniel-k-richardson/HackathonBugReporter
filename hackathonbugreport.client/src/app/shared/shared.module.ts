import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { NgbModule, NgbDateAdapter, NgbDateNativeAdapter } from '@ng-bootstrap/ng-bootstrap';

import { pipes } from './pipes';



@NgModule({
  declarations: [
    pipes,
  ],
  imports: [
    CommonModule,
    RouterModule,
    // FormsModule,
    // ReactiveFormsModule,
    NgbModule,
  ],
  exports: [
    CommonModule,
    RouterModule,
    // FormsModule,
    // ReactiveFormsModule,
    NgbModule,
    pipes,
  ],
  providers: [
    pipes,
    //{ provide: NgbDateAdapter, useClass: NgbDateNativeAdapter },
  ],
})
export class SharedModule {}
