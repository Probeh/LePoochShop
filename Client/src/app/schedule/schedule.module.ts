import { CommonModule             } from '@angular/common'
import { NgModule                 } from '@angular/core'
import { AppointmentFormComponent } from '@schedule/appointment-form/appointment-form.component'
import { AppointmentListComponent } from '@schedule/appointment-list/appointment-list.component'
import { AppointmentViewComponent } from '@schedule/appointment-view/appointment-view.component'
import { ScheduleComponent        } from '@schedule/schedule.component'
import { ScheduleRoutingModule    } from '@schedule/schedule.routing.module'
import { AppointmentFormService   } from '@services/appointment-form.service'

@NgModule({
  imports     : [CommonModule          , ScheduleRoutingModule                                                       ],
  declarations: [ScheduleComponent     , AppointmentViewComponent, AppointmentFormComponent, AppointmentListComponent],
  providers   : [AppointmentFormService                                                                              ]
})
export class ScheduleModule { }
