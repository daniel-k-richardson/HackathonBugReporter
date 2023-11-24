import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth.service';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.sass'
})
export class AppComponent implements OnInit {
  forecasts: WeatherForecast[] = [];
  isLoggedIn = false;
  private userAuthenticatedSubscription: any;

  constructor(
    private http: HttpClient,
    private authService: AuthService
  ) {
    this.userAuthenticatedSubscription = this.authService.userAuthenticated.subscribe(() => {
      this.isLoggedIn = this.authService.isLoggedIn();
    });
  }

  ngOnInit() {
    this.getForecasts();
  }

  ngOnDestroy() {
    this.userAuthenticatedSubscription.unsubsribe();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'hackathonbugreport.client';
}
