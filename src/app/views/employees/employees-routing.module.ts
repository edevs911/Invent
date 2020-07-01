import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeesComponent } from './employees.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';

export const routes: Routes = [
  { path: '', component: EmployeesComponent, children:[
    { path: "employee-detail/:index", component: EmployeeDetailComponent , canActivate: []},
    { path: "employee-detail", component: EmployeeDetailComponent, canActivate: [] },
    { path: "employee-list", component: EmployeeListComponent, canActivate: [] } 
  ]},
  
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
  
})
export class EmployeesRoutingModule { }
