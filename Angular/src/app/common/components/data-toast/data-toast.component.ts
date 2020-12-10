import { Component, OnInit } from '@angular/core'
import { ToastService } from '@assets/services/toast.service'

@Component({
  selector: 'app-toast',
  templateUrl: './data-toast.component.html',
  styleUrls: ['./data-toast.component.scss']
})
export class ToastComponent implements OnInit {
  // ======================================= //
  constructor(private toast: ToastService) { }
  // ======================================= //

  ngOnInit() {
  }

}
