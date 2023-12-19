import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LazymoduleRoutingModule } from './lazymodule-routing.module';
import { Comp1Component } from './comp1/comp1.component';
import { Comp2Component } from './comp2/comp2.component';



@NgModule({
  declarations: [
    Comp1Component,
    Comp2Component
  ],
  imports: [
    CommonModule,
    LazymoduleRoutingModule,
    FormsModule
  ]
})
export class LazymoduleModule { }
