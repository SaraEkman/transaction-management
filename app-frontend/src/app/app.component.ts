import { Component, OnInit } from "@angular/core";
import { DataService } from "./data.service";
import { Observable } from "rxjs";
import { Transaction } from "src/models/Transaction";
import { map } from "rxjs/operators";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent implements OnInit {
  title = "app-frontend";
  transactions$: Observable<Transaction[]> = new Observable();
  account_id: string = "";
  amount: number = 0;

  constructor(private dataService: DataService) {}

  ngOnInit() {
    this.transactions$ = this.dataService.getTransactions().pipe(
      map((transaction: Transaction[]) => {
        this.sortTransactions(transaction);
        return transaction;
      })
    );
  }

  addTransaction() {
    if (this.amount !== 0 && this.account_id !== "") {
      this.dataService
        .addTransaction(this.account_id, this.amount)
        .subscribe(newTransaction => {
          this.transactions$ = this.dataService.getTransactions().pipe(
            map((transaction: Transaction[]) => {
              this.sortTransactions(transaction);
              return transaction;
            })
          );
        });

      this.account_id = "";
      this.amount = 0;
    }
  }

  private sortTransactions(transaction: Transaction[]) {
    return transaction.sort(
      (a: any, b: any) =>
        new Date(b.created_at).getTime() - new Date(a.created_at).getTime()
    );
  }

  onFocus(event: FocusEvent) {
  const target = event.target as HTMLInputElement;
  if (target && target.value === "0") {
    target.value = "";
  }
}
}
