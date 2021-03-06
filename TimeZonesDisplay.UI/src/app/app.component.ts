import { Component, OnInit, Inject } from '@angular/core';
import { DataService } from "./services/data.service";
import { Observable } from "rxjs";
import { Timezone } from './models/timezone';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    timeZones: Timezone[];
    isLoading: boolean = true;

    constructor(@Inject(DataService) private dataService) { }

    ngOnInit() {
        this.dataService.getTimezones().subscribe(results => {
            this.timeZones = results;
            this.isLoading = false;
        }, error => {
            console.log(error);
            this.isLoading = false;
        });

        this.updateTime();
    }

    updateTime() {
        setInterval(() => {
            this.dataService.getTimezones().subscribe(results => {
                this.timeZones = results;
            }, error => console.log(error));
        }, 30000);
    }
}
