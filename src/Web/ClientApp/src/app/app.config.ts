import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { providePrimeNG } from 'primeng/config';
import Aura from '@primeng/themes/aura';

export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(withFetch()),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    // provideClientHydration(),
    provideAnimationsAsync(),
    providePrimeNG({
      theme: {
        preset: Aura,
      },
      translation: {
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
      },
    }),
  ],
};
