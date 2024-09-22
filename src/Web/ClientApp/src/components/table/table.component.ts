import { Component, Input } from '@angular/core';
import { Column } from '../../shared/types';
import { TableModule } from 'primeng/table';
import { ButtonDirective } from 'primeng/button';
import { Ripple } from 'primeng/ripple';
import { Router } from '@angular/router';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [TableModule, ButtonDirective, Ripple],
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss',
})
export class TableComponent<T> {
  @Input() cols: Column[];
  @Input() data: T[];

  constructor(private route: Router) {}

  selectRow(id: string) {
    this.route.navigate(['/isos', { drawingId: id }]);
  }
}
