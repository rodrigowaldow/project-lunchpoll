import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { PollComponent } from './poll/poll.component';
import { ResultComponent } from './result/result.component';
import { NavmenuComponent } from './navmenu/navmenu.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ChartModule } from 'angular-highcharts';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    PollComponent,
    ResultComponent,
    NavmenuComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgbModule,
    ChartModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: AppComponent },
      { path: 'poll', component: PollComponent },
      { path: 'results', component: ResultComponent },
      { path: '**', redirectTo: 'home' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
