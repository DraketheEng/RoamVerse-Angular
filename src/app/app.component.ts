import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'roamVerse';

  constructor(private router: Router) {}

  ngOnInit() {
    // Router'daki her sayfa değişikliğini dinle
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        // Sayfanın başına sürükle
        window.scrollTo(0, 0);
      }
    });
  }
}
