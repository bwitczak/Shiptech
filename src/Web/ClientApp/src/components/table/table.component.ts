import { Component, Input } from '@angular/core';
import { Column } from '../../shared/types';
import { TableModule } from 'primeng/table';
import { Ripple } from 'primeng/ripple';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [TableModule, Ripple, ButtonModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss',
})
export class TableComponent<T> {
  @Input() cols: Column[];
  @Input() data: T[];
  @Input() filterFields: string[];
  @Input() action?: (number: string) => string;
}
