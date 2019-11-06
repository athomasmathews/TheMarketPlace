import { Component } from '@angular/core';

@Component({
    selector: 'app-confirmationcancel',
    templateUrl: './confirmationcancel.component.html'
})

export class ConfirmationCancelComponent {
    confirmationmessage: string = "Your order item cancelled successfully.";
}
