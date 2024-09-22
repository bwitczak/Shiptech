import { Component, Input } from '@angular/core';
import { Column } from '../../shared/types';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [TableModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss',
})
export class TableComponent<T> {
  @Input() cols: Column[];
  @Input() data: T[];
}
