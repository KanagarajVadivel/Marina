import { Component, OnInit } from '@angular/core';
import { HomeService }         from './home.service';

@Component({
    moduleId: module.id,
    selector: 'home',
    templateUrl: 'home.component.html'
})
export class HomeComponent implements OnInit {

    constructor(private homeService: HomeService) { }

    ngOnInit() {
        this.homeService.getUser().then(p => console.log(p));
    }

}