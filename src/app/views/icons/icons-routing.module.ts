import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CoreUIIconsComponent } from './coreui-icons.component';
import { FontAwesomeComponent } from './font-awesome.component';


const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Icons'
    },
    children: [
      {
        path: '',
        redirectTo: 'coreui-icons'
      },
      {
        path: 'coreui-icons',
        component: CoreUIIconsComponent,
        data: {
          title: 'CoreUI Icons'
        }
      },
      {
        path: 'font-awesome',
        component: FontAwesomeComponent,
        data: {
          title: 'Font Awesome'
        }
      }
    
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IconsRoutingModule {}
