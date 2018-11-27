import { Component, OnInit } from '@angular/core';
import { Observable, of} from 'rxjs';
import { map, catchError, startWith, debounceTime, switchMap} from 'rxjs/operators'
import { FormControl } from '@angular/forms';
import { PersonService } from './person.service';
import { Person } from './person';

@Component({
  selector: 'app-person-search',
  templateUrl: './person-search.component.html',
  styleUrls: ['./person-search.component.css']
})
export class PersonSearchComponent implements OnInit {

  public autoComplete$: Observable<Person> = null;
  public autoCompleteControl = new FormControl();

  constructor(private service: PersonService) { }

  ngOnInit() {
    this.autoComplete$ = this.autoCompleteControl.valueChanges.pipe(
      startWith(''),
      // delay emits
      debounceTime(300),
      // use switch map so as to cancel previous subscribed events, before creating new once
      switchMap(value => {
        if (value !== '') {
          // lookup from github
          console.log(value);

          return this.lookup(value);
        } else {
          // if no value is present, return null
          return of(null);
        }
      })
    );
  }

  lookup(value: string): Observable<any> {
    return this.service.search(value.toLowerCase());
  }
}
