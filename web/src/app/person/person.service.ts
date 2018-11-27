import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private http: HttpClient) { }

  get(id: string) {

    let url = environment.apiUrl + 'person' + '/' + id;

    return this.http.get(url);

  }

  create(person){

    let url = environment.apiUrl + 'person';

    return this.http.post(url, person);
  }

  update(person){

    let url = environment.apiUrl + 'person';

    return this.http.put(url, person);
  }

  delete(id){

    let url = environment.apiUrl + 'person' + '/' + id;

    return this.http.delete(id);
  }

  list() {

    let url = environment.apiUrl + 'person';

    return this.http.get(url);

  }

  search(term: string) {

    let url = environment.apiUrl + 'person/search/' + term;

    return this.http.get(url);

  }
}
