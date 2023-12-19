import { Component } from '@angular/core';
import { UserserviceService } from '../userservice.service';

@Component({
  selector: 'app-updatecomp',
  templateUrl: './updatecomp.component.html',
  styleUrls: ['./updatecomp.component.css']
})
export class UpdatecompComponent {
  constructor(private user:UserserviceService){}
  update(data:any){
    const stid={
      "sid":data.value.id
    }
    const updates={
      "sname":data.value.fname,
      "sage":data.value.age,
      "saddress":data.value.address,
      "phone":data.value.phone
    }

    this.user.updateProduct(stid.sid,updates).subscribe(udata=>{console.log(udata)})
  }
}
