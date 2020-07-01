import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersRoutingModule } from './user-routing.module';
import { UsersComponent } from './users.component';
import {DragDropModule} from '@angular/cdk/drag-drop';



@NgModule({
  declarations: [UsersComponent],
  imports: [
    CommonModule, UsersRoutingModule, DragDropModule
  ]
})
export class UserModule { }
