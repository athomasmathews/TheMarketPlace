import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DOCUMENT } from '@angular/common';
import { Router } from '@angular/router';

@Component({
    selector: 'app-cart',
    templateUrl: './cart.component.html'
})

export class CartComponent {
    public items: ItemsDetails[];
    public selected: string = 'price';
    public checkeditems: any[];


    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, @Inject(DOCUMENT) private document: Document, private router: Router) {

        http.get<ItemsDetails[]>(baseUrl + 'api/MyItems').subscribe(result => {
            this.items = result;
        }, error => console.error(error));
    }
    myfun() {
        this.checkeditems = this.items.filter(d => d.checked == true);
        this.http.post(this.document.location.origin + '/api/MyItems/CancelledProducts', this.items).subscribe(
            (res: any) => {
                this.router.navigateByUrl('/cancel');
            },
            err => {
                console.log(err);
            }
        )
    }

    sortTable() {
        this.items.sort((a, b) => {
            return -1;
        });
    }
}
interface ItemsDetails {
    id: number,
    name: string,
    path: string,
    description: string,
    price: number,
    checked: boolean
}
