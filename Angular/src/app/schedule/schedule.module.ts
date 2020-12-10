import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ScheduleRoutingModule } from '@schedule/schedule-routing.module';
import { ScheduleComponent } from '@schedule/schedule.component';

@NgModule({
  imports: [CommonModule, ScheduleRoutingModule],
  declarations: [ScheduleComponent]
})
export class ScheduleModule { }
