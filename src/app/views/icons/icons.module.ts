import { NgModule } from '@angular/core';

import { CoreUIIconsComponent } from './coreui-icons.component';
import { FontAwesomeComponent } from './font-awesome.component';


import { IconsRoutingModule } from './icons-routing.module';

@NgModule({
  imports: [ IconsRoutingModule ],
  declarations: [
    CoreUIIconsComponent,
    FontAwesomeComponent,
  ]
})
export class IconsModule { }
