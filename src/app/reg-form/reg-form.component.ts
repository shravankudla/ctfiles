import { Component } from '@angular/core';
import { UserserviceService } from '../userservice.service';

@Component({
  selector: 'app-reg-form',
  templateUrl: './reg-form.component.html',
  styleUrls: ['./reg-form.component.css']
})
export class RegFormComponent {
  constructor(private user:UserserviceService){}
  submit(data:any){
    console.log(data.value);
    const studInput={
      "sname":data.value.fname,
      "sage":data.value.age,
      "saddress":data.value.address,
      "phone":data.value.phone
    }
    this.user.addProduct(studInput).subscribe(result=>{
      console.log(result);
    })
    // this.data=data.value;
  }
}
