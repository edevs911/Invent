import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeesComponent } from './employees.component';
import { EmployeesRoutingModule } from './employees-routing.module';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';


@NgModule({
  declarations: [EmployeesComponent, EmployeeDetailComponent, EmployeeListComponent],
  imports: [
    EmployeesRoutingModule,
    CommonModule
  ]
})

export class EmployeesModule { }
