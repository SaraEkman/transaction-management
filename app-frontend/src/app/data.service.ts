import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Transaction } from "src/models/Transaction";

@Injectable({
  providedIn: "root"
})
export class DataService {
  api: string = "https://localhost:7207";

  constructor(private http: HttpClient) { }

  getTransactions(): Observable<Transaction[]> {
    return this.http.get<Transaction[]>(`${this.api}/transactions/`);
  }

  addTransaction(account_id: string, amount: number): Observable<Transaction> {
    return this.http.post<Transaction>(`${this.api}/transactions`, { account_id, amount }, { headers: { "Content-Type": "application/json" } });
  }

  getTransaction(transactionId: string):Promise<Transaction> {
    return fetch(`${this.api}/transactions/${transactionId}`)
      .then(response => response.json());
  }

  getAccount(accountId: string) {
    return this.http.get(`${this.api}/accounts/${accountId}`);
  }
}
