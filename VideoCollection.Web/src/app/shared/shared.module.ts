import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { ApiService } from "./api.service";
import { AuthGuardService } from "./auth-guard.service";

const providers = [
    ApiService,
    AuthGuardService
];

@NgModule({
    imports: [CommonModule],
	providers: providers
})
export class SharedModule { }
