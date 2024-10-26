import { Component, inject } from '@angular/core';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { TopBarService } from '../../services/topBarService';
import { ChevronRight, LucideAngularModule } from 'lucide-angular';
import { RouterLink } from '@angular/router';
import { NgTemplateOutlet } from '@angular/common';

@Component({
  selector: 'app-topbar',
  standalone: true,
  imports: [
    SidebarComponent,
    LucideAngularModule,
    RouterLink,
    NgTemplateOutlet,
  ],
  templateUrl: './topbar.component.html',
  styleUrl: './topbar.component.scss',
})
export class TopbarComponent {
  readonly ChevronRight = ChevronRight;

  private topBarService = inject(TopBarService);

  breadcrumbItems = this.topBarService.getBreadcrumbItems();
  topBarButton = this.topBarService.contentSignal;
}
