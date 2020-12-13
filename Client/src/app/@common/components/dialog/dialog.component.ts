import { Component, OnInit } from '@angular/core'
import { DialogService } from '@services/dialog.service'

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {
  constructor(private service: DialogService) {
    this.service.hideDialog$.subscribe({ next: () => this.hideDialog() });
    this.service.showDialog$.subscribe({ next: () => this.showDialog() });
  }

  ngOnInit() { }

  public showDialog() {
    const dialog = document.getElementById("dialog");
    dialog.style.display = "block";
  }
  public hideDialog() {
    const dialog = document.getElementById("dialog");
    dialog.style.display = "none";
  }
}