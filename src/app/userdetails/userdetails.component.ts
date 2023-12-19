import { Component ,OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-userdetails',
  templateUrl: './userdetails.component.html',
  styleUrls: ['./userdetails.component.css']
})
export class UserdetailsComponent implements OnInit{
  constructor(private routes:ActivatedRoute){}
  id:any;
  ngOnInit(): void {
    console.log(this.routes.snapshot.params);
    this.id=this.routes.snapshot.params['id'];
  }

}
