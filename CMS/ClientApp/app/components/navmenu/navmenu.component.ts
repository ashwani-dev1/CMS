import { Component } from '@angular/core';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {

    constructor() {

    }
    Signout() {
        window.localStorage.setItem("userName", "undefined");
        window.location.href = "/login";
    }
}
