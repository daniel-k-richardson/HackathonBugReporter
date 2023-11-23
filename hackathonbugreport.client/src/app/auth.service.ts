import { Injectable, EventEmitter } from '@angular/core';
import { User, UserManager, UserManagerSettings, WebStorageStateStore } from 'oidc-client';
import { BehaviorSubject } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  user: User;
  userEmailOrName: BehaviorSubject<string> = new BehaviorSubject('');
  userAuthenticated: EventEmitter<string> = new EventEmitter();
  private userManager: UserManager;

  isRestrictedAdmin = false;

  constructor() {
    this.userManager = this.getUserManager();

    this.userManager.events.addSilentRenewError(() => {
      sessionStorage.setItem('loggedOutDueToInactivity', 'true');
      this.logout();
    });

    this.userManager.events.addUserLoaded((user: User) => {
      if (user && !user.expired) {
        this.setCurrentUser(user);
      }
    });
    this.userManager.events.addUserUnloaded(() => {});

    this.userManager
      .getUser()
      .then(user => {
        if (user && !user.expired) {
          this.setCurrentUser(user);
        }
      })
      .catch(err => {
        console.error(err);
      });
  }

  getUserManager(): UserManager {
    const baseUrl = window.location.origin;

    const responseType = environment.usePKCE ? 'code' : 'id_token token';

    const settings: UserManagerSettings = {
      authority: environment.authority,
      client_id: environment.client_id,
      redirect_uri: baseUrl + '/assets/auth.html',
      silent_redirect_uri: baseUrl + '/assets/silent-renew.html',
      response_type: responseType,
      post_logout_redirect_uri: baseUrl,
      scope: 'profile openid AppFramework',
      filterProtocolClaims: true,
      loadUserInfo: true,
      automaticSilentRenew: true,
      userStore: new WebStorageStateStore({ store: window.localStorage }),
      includeIdTokenInSilentRenew: false,
      accessTokenExpiringNotificationTime: 300,
      silentRequestTimeout: 20000
    };

    return new UserManager(settings);
}

  startAuthentication() {
    return this.userManager.signinRedirect();
  }

  completeAuthentication(): Promise<any> {
    return this.userManager.signinRedirectCallback();
  }

  getAuthorizationHeaderValue(): string {
    return this.user && `${this.user.token_type} ${this.user.access_token}`;
  }

  isLoggedIn(): boolean {
    return this.user && !this.user.expired;
  }

  logout() {
    delete this.user;
    this.userManager.signoutRedirect();
  }

  private setCurrentUser(user: User) {
    this.user = user;
    this.userEmailOrName.next(user.profile.email || user.profile.preferred_username);
    this.userAuthenticated.emit(user.access_token);
  }
}
