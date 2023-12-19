import { Component } from '@angular/core';

import { UserserviceService } from 'src/app/userservice.service';
@Component({
  selector: 'app-comp1',
  templateUrl: './comp1.component.html',
  styleUrls: ['./comp1.component.css']
})
export class Comp1Component {
  userInfo:any;
  // info={
  //   sname:"Tarun",
  //   sage:21,
  //   saddress:"Mangalore",
  //   phone:"1234567"
  // }
  num=1001;
  up={
    sname: "Ashwitha",
    sage: 18,
    saddress: "puttur",
    phone: "999888777"
}
  // numb=53;
  constructor(private user:UserserviceService){
    let data=this.user.getUserData().subscribe(udata=>{
      console.log(udata)
      this.userInfo=udata;
      // console.log(this.userInfo);
    });
   
  }
  // add(){
  //   this.user.addProduct(this.info).subscribe(udata=>console.log(udata))
  // }
  delete(data:any){
    const stid={
    "sid":data.value.id
    }
    this.user.deleteProduct(stid.sid).subscribe(udata=>console.log(udata))
  }
 

  
}
