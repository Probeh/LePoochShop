import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataFormComponent } from './data-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FormService } from '@common/components/data-form/data-form.service';

@NgModule({
  imports: [CommonModule, ReactiveFormsModule],
  declarations: [DataFormComponent],
  providers: [FormService],
  exports: [DataFormComponent]
})
export class DataFormModule { }
