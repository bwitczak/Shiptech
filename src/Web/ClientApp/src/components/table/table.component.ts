import { Component, Input } from '@angular/core';
import { Column } from '../../shared/types';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { ListCollapse, LucideAngularModule } from 'lucide-angular';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [TableModule, ButtonModule, LucideAngularModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss',
})
export class TableComponent<T> {
  @Input() cols: Column[];
  @Input() data: T[];
  @Input() filterFields: string[];
  @Input() action?: (number: string) => string;

  readonly ListCollapse = ListCollapse;
}
