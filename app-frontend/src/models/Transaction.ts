export class Transaction {
    constructor(public transaction_id: string, public account_id: string, public amount: number, public created_at: Date,public current_account_balance: number) {
    }
}
