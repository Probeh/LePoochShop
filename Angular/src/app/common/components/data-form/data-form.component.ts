import { Component, OnInit } from '@angular/core'
import { FormService } from '@common/components/data-form/data-form.service'

@Component({
  selector: 'app-data-form',
  templateUrl: './data-form.component.html',
  styleUrls: ['./data-form.component.scss']
})
export class DataFormComponent implements OnInit {

  constructor(private service: FormService) { }

  ngOnInit() {
  }

}
