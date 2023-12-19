import { Component } from '@angular/core';
import { FormGroup, FormControl,Validators} from '@angular/forms'
@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent {
  signinform=new FormGroup({
    un:new FormControl('',[Validators.required,Validators.minLength(3),Validators.maxLength(9)]),
    ps:new FormControl('',[Validators.required,Validators.minLength(8)])
  })

  get un(){
    return this.signinform.get('un');
  }

  get ps(){
    return  this.signinform.get('ps')
  }
  signin(){
    console.log(this.signinform.value);
  }

}
