import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TransactionsService {
  url = "https://localhost:7037/api/Transactions/Upload";
  formData = new FormData();
  constructor(private http: HttpClient) {

  }

  public uploadFile(file:File) {
    let formData = new FormData();
    formData.append('file', file)
    return this.http.post(this.url, formData);
  }
}
