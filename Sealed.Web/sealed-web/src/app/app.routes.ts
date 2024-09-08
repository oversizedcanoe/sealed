import { Routes } from '@angular/router';
import { ViewCodeComponent } from './features/view-code/view-code.component';
import { LandingPageComponent } from './features/landing-page/landing-page.component';

export const routes: Routes = [
    {path: '', component: LandingPageComponent},
    {path: 'viewcode', component: ViewCodeComponent}
];
