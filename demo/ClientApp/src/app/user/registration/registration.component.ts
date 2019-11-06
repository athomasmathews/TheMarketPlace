import { Component } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { element } from 'protractor';

@Component({
    selector: 'app-registration-component',
    templateUrl: './registration.component.html'
})
export class RegistrationComponent {
    constructor(public service: UserService) {
    }
    ngOnInit() {
        this.service.formModel.reset();
    }
    onSubmit() {
        this.service.register().subscribe(
            (res: any) => {
                if (res.succeeded) {
                    this.service.formModel.reset();
                }
                else {
                    res.errors.forEach(element => {
                        switch (element.code) {
                            case 'DuplicateUserName':
                                //username is already taken
                                break;
                            default:
                                //registration failed
                                break;
                        }
                    }
                    )
                }
            },
            err => {
                console.log(err);
            }
        )
    }
}
