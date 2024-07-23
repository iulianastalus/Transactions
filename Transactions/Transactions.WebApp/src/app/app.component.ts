import { Component } from '@angular/core';
import { TransactionsService } from './transactions.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Transactions.WebApp';
  errorMessage = "";
  constructor(private transactionsService: TransactionsService) { }

  checkFileFormat(fileEvent: Event) {
    const target = fileEvent.target as HTMLInputElement;
    const file: File = target.files![0];
    if (file) {
      if (file.type != "text/csv" && file.type != "text/xml") {
        this.errorMessage = "Unknown Format !"
      } else {
        this.transactionsService.uploadFile(file).subscribe()
      }
    }
  }
}
