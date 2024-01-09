import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class DataService {
  api: string = "https://localhost:7207";

  constructor(private http: HttpClient) { }

  getTransactions() {
    return this.http.get(`${this.api}/transactions/`);
  }

  addTransaction(account_id: string, amount: number) {
    return this.http.post(`${this.api}/transactions`, { account_id, amount }, { headers: { "Content-Type": "application/json" } });
  }

  getTransaction(transactionId: string) {
    return fetch(`${this.api}/transactions/${transactionId}`)
      .then(response => response.json());
  }

  getAccount(accountId: string) {
    return this.http.get(`${this.api}/accounts/${accountId}`);
  }
}
