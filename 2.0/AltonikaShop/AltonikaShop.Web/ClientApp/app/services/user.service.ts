import { Injectable } from '@angular/core';
import { LocalStorage } from 'nglib';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';

@Injectable()
export class UserService {
    currentUserKey = 'currentUser';

    constructor(
        private _localStorage: LocalStorage,
        private _http: HttpClient) {

    }

    hasCurrentUser() {
        return this._localStorage.get(this.currentUserKey) !== null;
    }

    setCurrentUser(user: any) {
        this._localStorage.set(this.currentUserKey, user);
    }

    getCurrentUser() {
        return JSON.parse(this._localStorage.get(this.currentUserKey));
    }

    removeCurrentUser() {
        this._localStorage.remove(this.currentUserKey);
    }

    auth(user: any) {
        return this._http.post(environment.apiUrl + 'user', user);
    }
}
