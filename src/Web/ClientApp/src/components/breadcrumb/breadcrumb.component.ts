import { Component, Input } from '@angular/core';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { MenuItem, PrimeTemplate } from 'primeng/api';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-breadcrumb',
  standalone: true,
  imports: [BreadcrumbModule, PrimeTemplate, NgClass],
  templateUrl: './breadcrumb.component.html',
  styleUrl: './breadcrumb.component.scss',
})
export class BreadcrumbComponent {
  @Input() navigation: MenuItem[];
}
