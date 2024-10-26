import { Component, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { SidebarComponent } from '../components/sidebar/sidebar.component';
import { PrimeNGConfig } from 'primeng/api';
import { Aura } from 'primeng/themes/aura';
import { TopbarComponent } from '../components/topbar/topbar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SidebarComponent, TopbarComponent],
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

    this.primengConfig.theme.set({
      preset: Aura,
      options: {
        cssLayer: {
          name: 'primeng',
          order: 'tailwind-base, primeng, tailwind-utilities',
        },
      },
    });
  }
}
