import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Observable, Subject } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'app-frontend';
  transactions: any = []
  account_id: string = "";
  amount: number = 0;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.dataService.getTransactions().subscribe((data) => {
      this.transactions = data;
     this.sortTransactions();
    });
  }

  addTransaction() {
    console.log("this.account_id",this.account_id), console.log("this.amount",this.amount);
    if (this.amount !== 0 && this.account_id !== "") {
      this.dataService.addTransaction(this.account_id, this.amount).subscribe((data: any) => {
        this.transactions.unshift(data);
        this.sortTransactions();
        this.account_id = "";
        this.amount = 0;
      });
    }
  }

  private sortTransactions() {
    this.transactions = this.transactions.sort((a:any, b:any) => new Date(b.created_at).getTime() - new Date(a.created_at).getTime())
  }

   onFocus(event: any) {
    if (event.target.value === '0') {
      event.target.value = '';
    }
  }
}
