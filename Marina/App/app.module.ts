import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';
import { HttpModule }    from '@angular/http';

import { AppComponent }         from './app.component';
import { HomeComponent }         from './home/home.component';
import { HomeService }         from './home/home.service';
import { AppHeaderComponent }         from './widgets/app-header/app-header.component';
import { AppFooterComponent }         from './widgets/app-footer/app-footer.component';
import { MenuAsideComponent }         from './widgets/menu-aside/menu-aside.component';

import { routing } from './app.routing';
import './rxjs-extensions';


@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        AppHeaderComponent,
        AppFooterComponent,
        MenuAsideComponent
    ],
    providers: [
        HomeService
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}

