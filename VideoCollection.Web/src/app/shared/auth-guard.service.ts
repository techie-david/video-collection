﻿import { Injectable } from "@angular/core";
import {
    CanActivate,
    CanActivateChild,
    CanLoad,
    Route,
    Router,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router';

import { CurrentUserService } from "./current-user.service";
import { LoginRedirectService } from "./login-redirect.service";

@Injectable()
export class AuthGuardService implements CanActivate {
    constructor(
        private _currentUserService: CurrentUserService,
        private _loginRedirectService: LoginRedirectService,
        private _router: Router
    ) {

    }

    public canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ) {

        if (this._currentUserService.isLoggedIn) { return true; }

        this._loginRedirectService.lastPath = state.url;
        this._router.navigate(['/login']);
        return false;
    }
}