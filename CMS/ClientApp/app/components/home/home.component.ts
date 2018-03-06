import { Component } from '@angular/core';
import { Router } from '@angular/router';
@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    constructor(private router: Router) {
       
       
    }
    ngAfterViewInit() {
        debugger;
        let userName = localStorage.getItem("userName");
        if (userName == undefined || userName == null || userName == "undefined") {
            this.router.navigate(['login']);           
        }
    }
}
