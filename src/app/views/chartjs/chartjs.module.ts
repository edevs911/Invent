import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts';

import { ChartJSComponent } from './chartjs.component';
import { ChartJSRoutingModule } from './chartjs-routing.module';
import {DragDropModule} from '@angular/cdk/drag-drop';
import { CommonModule } from "@angular/common";

@NgModule({
  imports: [
    ChartJSRoutingModule,
    ChartsModule,
    DragDropModule,
    CommonModule
  ],
  declarations: [ ChartJSComponent ]
})
export class ChartJSModule { }
