import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AdminLayoutComponent } from './admin/admin-layout/admin-layout.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
    {
      path: '',
      component: HomeComponent,
      title: 'Home page qq'
    },
    {
      path: 'admin',
      component: AdminLayoutComponent,
      title:'Admin'
    }
  ];
  
  @NgModule({
    imports: [ RouterModule.forRoot(routes) ],
    exports: [ RouterModule ]
  })
  export class AppRoutingModule {}