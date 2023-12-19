import { Component } from '@angular/core';
import { UserserviceService } from 'src/app/userservice.service';
@Component({
  selector: 'app-comp2',
  templateUrl: './comp2.component.html',
  styleUrls: ['./comp2.component.css']
})
export class Comp2Component {
  info:any;
  constructor(private user:UserserviceService){
    let data=this.user.getplaceHolderData().subscribe(udata=>{
      console.log(udata)
      this.info=udata;
    
    })

  }
}
