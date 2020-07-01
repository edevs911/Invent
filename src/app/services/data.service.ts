import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';
import { User } from '../models/user.model'
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class DataService {

  employeeList: Array<Employee> = [];
  userList: Array<User> = [];

  constructor(
    private httpClient: HttpClient
  ) { }

  getEmployees(): Observable<any> {
    return this.httpClient.get(environment.api + '/users?delay=1');
  }

  find(path, params?): Observable<any> {
    return this.httpClient.get(environment.api + path + params);
  }

  findById(path, id): Observable<any> {
    return this.httpClient.get(environment.api + path + "/" + id);
  }

  getEmployee(id) {
    //return this.employeeList[id];
    return this.httpClient.get(environment.api + '/users/' + id);
  }

  updateEmployee(id, employee) {
    //this.employeeList[index] = employee;
    return this.httpClient.put(environment.api + '/users/' + id, employee);
  }

  setEmployee(employee: Employee) {
    if (!this.employeeList) {
      this.employeeList = [];
    }
    this.employeeList.push(employee);
  }

  getProducts(): Observable<any> {
    return this.httpClient.get("assets/products.json");
  }

  deleteEmployee(id: number): Observable<any> {
    //this.employeeList.splice(index, 1);
    return this.httpClient.delete(environment.api + '/users/' + id);
  }


  getUsers(): Observable<any> {
    return this.httpClient.get(environment.api + '/users?delay=1');
  }

  findUser(path, params?): Observable<any> {
    return this.httpClient.get(environment.api + path + params);
  }

  findUserById(path, id): Observable<any> {
    return this.httpClient.get(environment.api + path + "/" + id);
  }

  getUser(id) {
    //return this.employeeList[id];
    return this.httpClient.get(environment.api + '/users/' + id);
  }

  updateUser(id, employee) {
    //this.employeeList[index] = employee;
    return this.httpClient.put(environment.api + '/users/' + id, employee);
  }

  setUsers(employee: Employee) {
    if (!this.employeeList) {
      this.employeeList = [];
    }
    this.employeeList.push(employee);
  }

  deleteUsers(id: number): Observable<any> {
    //this.employeeList.splice(index, 1);
    return this.httpClient.delete(environment.api + '/users/' + id);
  }



}
