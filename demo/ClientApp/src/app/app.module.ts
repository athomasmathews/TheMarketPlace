import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SortByPipe } from './sortbypipe';

import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserService } from './shared/user.service';
import { LoginComponent } from './user/login/login.component';
import { AuthGuard } from './auth/auth.guard';
import { AuthInterceptor } from './auth/auth.interceptor';
import { ConfirmationComponent } from './home/confirmation.component';
import { CartComponent } from './Cart/cart.component';
import { ConfirmationCancelComponent } from './cart/confirmationcancel.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent,
        SortByPipe,
        UserComponent,
        RegistrationComponent,
        LoginComponent,
        ConfirmationComponent,
        CartComponent,
        ConfirmationCancelComponent

    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: '/user/login', pathMatch: 'full' },
            {
                path: 'user', component: UserComponent,
                children: [
                    { path: 'login', component: LoginComponent },
                    { path: 'registration', component: RegistrationComponent }
                    
                ]
            },
            //{ path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
            { path: 'confirmation', component: ConfirmationComponent },
            { path: 'Cart', component: CartComponent },
            { path: 'cancel', component: ConfirmationCancelComponent },
            { path: 'fetch-data', component: FetchDataComponent }
        ])
    ],
    providers: [UserService, {
        provide: HTTP_INTERCEPTORS,
        useClass: AuthInterceptor,
        multi: true
    }],
    bootstrap: [AppComponent]
})
export class AppModule { }
