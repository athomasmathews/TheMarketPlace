import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DOCUMENT } from '@angular/common';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
    public items: ItemsDetails[];
    public selected: string = 'price';
    public checkeditems: any[];


    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, @Inject(DOCUMENT) private document: Document, private router: Router) {

        http.get<ItemsDetails[]>(baseUrl + 'api/home').subscribe(result => {
            this.items = result;
        }, error => console.error(error));


        //this.items = [
        //    { id: 1, path: '/images/FavaSofa-Grey.jpg', description: 'The Fava sofa offers up a perfect look and feel when you need a place to unwind. Soft to the touch yet durable enough for your high-traffic space, the quality grey fabric has subtly textured appeal, and the patterned pillows boast laid-back glamour — all coming together in one gorgeous look. The tailored box cushions and bold track arms ensure lasting comfort. Made in Canada.', price: 1000.09, checked:false },
        //    { id: 2, path: '/images/NaplesSofa-WarmBeige.jpg', description: 'You will love talking and laughing with family and friends when you sit in the stylish, supple Naples sofa in warm beige.Take the time to linger over a comedic film or witty conversation with the supportive cushioning and coils of the seats and back.Pillowtop arms, designer stitching and richly coloured wedge feet round out this smart, modern look.Made in Canada.', price: 2005, checked: false},
        //    { id: 3, path: '/images/XoomConvertibleSofa-Black.jpg', description: 'The versatile Xoom convertible sofa helps you make the most of your space. It is perfect in an office, teens room, living room or anyplace you could use a sofa that doubles as a spot for overnight guests. It converts to a bed in seconds, and the innerspring coils are made by Serta, so you know guests will sleep comfortably. The leather-look upholstery in black is sleek and stylish, plus it is easy to clean and maintain.', price: 3000.59, checked: false}
        //];
    }
    myfun() {
        //console.log(this.items.filter(d => d.checked == true).length);
        this.checkeditems = this.items.filter(d => d.checked == true);
        console.log(this.items);
        this.http.post(this.document.location.origin + '/api/Home/SelectedProducts', this.items).subscribe(
            (res: any) => {
                this.router.navigateByUrl('/confirmation');
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
        //this.items.sort((a, b) => {
        //    const name1 = a.price;
        //    const name2 = b.price;
        //    console.log(name1);
        //    console.log(name2);
        //    if (name1 < name2) {
        //        console.log(1);
        //        return 1;
        //    }
        //    if (name1 > name2) {
        //        console.log(-1);
        //        return -1;
        //    }
        //    console.log(0);
        //    return 0;
        //});
        
    }
}
interface ItemsDetails {
    id: number,
    name:string,
    path: string,
    description: string,
    price: number,
    checked:boolean
}
