export class User {
    name:string;
    lastName: string;
    number: number;
    data:any;
    role:Array<string>;
    responsabilities: Array<string>;
  
    constructor(
      name?:string, 
      lastName?:string, 
      number?: number,
      responsabilities?:Array<string>,
      role?:Array<string>
    ){
      this.name = name;
      this.lastName = lastName;
      this.number = number;
      this.responsabilities = responsabilities;
      this.role= role;
    }
  }