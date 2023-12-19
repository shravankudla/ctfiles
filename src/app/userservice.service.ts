import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UserserviceService {

  constructor(private http:HttpClient) { }
  getUserData(){
    return this.http.get('http://localhost:3000/employee');
  }

  getplaceHolderData(){
    return this.http.get('https://jsonplaceholder.typicode.com/users');
  }
  
  addProduct(input:any){
    return this.http.post('http://localhost:3000/employee',input);
  }

  deleteProduct(input:any){
    return this.http.delete('http://localhost:8080/api/student/'+input);
  }
  
  updateProduct(input:any,updates:any){
    return this.http.put('http://localhost:8080/api/student/'+input+'',updates);
  }
}
