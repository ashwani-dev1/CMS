import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(
        private router: Router
    ) {

    }

    isLoginPage: boolean = false;
    ngOnInit() {
        let url = window.location.href;        
        if (url.indexOf("login") > -1) {
            this.isLoginPage = true;
        }
    }
}
