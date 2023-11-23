import { Component } from '@angular/core';
import {Router} from '@angular/router';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass'],
})
export class LoginComponent {

  constructor(
    public authService: AuthService,
    private router: Router
  ) {
    if (this.authService.isLoggedIn()) {
      this.router.navigateByUrl('/');
    }
  }
}
