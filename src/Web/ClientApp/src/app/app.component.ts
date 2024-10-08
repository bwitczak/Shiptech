import { Component, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { SidebarComponent } from '../components/sidebar/sidebar.component';
import { PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SidebarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  constructor(
    private primengConfig: PrimeNGConfig,
    protected router: Router
  ) {}

  ngOnInit() {
    this.primengConfig.setTranslation({
      startsWith: 'Zaczyna się',
      contains: 'Zawiera',
      notContains: 'Nie zawiera',
      endsWith: 'Kończy się',
      equals: 'Równe',
      notEquals: 'Nie równe',
      noFilter: 'Resetuj filtry',
      matchAll: 'Dopasuj wszystko',
      matchAny: 'Dopasuj dowolny',
      addRule: 'Dodaj regułę',
      removeRule: 'Usuń regułę',
      clear: 'Wyczyść',
      apply: 'Zatwierdź',
    });
  }
}
