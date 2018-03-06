import { Component, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Router } from '@angular/router';

@Component({
    selector: 'loginwindow',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {

    username: string = "";
    password: string = "";
    public formPost = new OTPLogin();
    public passwordLogin = new PasswordLogin();
    constructor(private router: Router, private http: Http, @Inject('BASE_URL') private baseUrl: string) {

    }
    ngAfterViewInit() {
        debugger;
        let userName = localStorage.getItem("userName");
        if (userName != undefined && userName != null && userName != "undefined") {
            window.location.href = "/home";
        }
    }
    PasswordLogin() {
        debugger;
        this.passwordLogin.Password = this.password;
        this.passwordLogin.Username = this.username;
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify(this.passwordLogin);
        return this.http.post(this.baseUrl + 'api/ManageCustomer/PasswordLogin', body, options).subscribe(
            (res: Response) => {
                var result = res.json();
                if (result.message == "success") {
                    window.localStorage.setItem("userName", result.username);
                    //this.router.navigate(['home'])
                    window.location.href = "/home";
                }
                else {
                    alert(result.message);
                }

            }
            , (err) => {
                //window.localStorage.setItem("errorSet", err.json().ExceptionMessage + "," + err.json().Message);
            });
    }

    OTPLogin() {      
        //Send OTP to register Phone number
        if (this.username != "" && this.password == "") {
            this.http.get(this.baseUrl + 'api/ManageCustomer/SendSMS?userName=' + this.username).subscribe(result => {               
                alert(result.json().message);
            }, error => console.error(error));

        }
        else if (this.username != "" && this.password != "") {
            //Login with OTP
            this.formPost.Username = this.username;
            this.formPost.OTP = this.password;
            this.formPost.Message = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });
            let body = JSON.stringify(this.formPost);
            return this.http.post(this.baseUrl + 'api/ManageCustomer/OTPLogin', body, options).subscribe(
                (res: Response) => {                   
                    var result = res.json();
                    if (result.message == "success") {
                        window.localStorage.setItem("userName", result.username);
                        //this.router.navigate(['home'])
                        window.location.href = "/home";
                    }
                    else {
                        alert(result.message);
                    }
                  
                }
                , (err) => {
                    //window.localStorage.setItem("errorSet", err.json().ExceptionMessage + "," + err.json().Message);

                  
                   
                });
        }
        else {
            alert("Please enter credentials to login");
        }

    }
}
export class OTPLogin {
    Username: string;
    OTP: string;
    Message: string;
}
export class PasswordLogin {
    Username: string;
    Password: string;
    Message: string;
}