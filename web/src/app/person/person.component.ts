import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  personId: string;

  constructor(private route:ActivatedRoute){}

  ngOnInit() {

    this.route.params.subscribe( params => {
      
      console.log(params) 
      
      this.personId = params['id']
    });
  }
}
