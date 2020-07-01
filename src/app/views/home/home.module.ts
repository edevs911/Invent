import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import {DragDropModule} from '@angular/cdk/drag-drop';

@NgModule({
  declarations: [HomeComponent],
  imports: [HomeRoutingModule, CommonModule,DragDropModule]  
})
export class HomeModule { }


