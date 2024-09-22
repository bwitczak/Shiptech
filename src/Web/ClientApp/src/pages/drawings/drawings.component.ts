import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DrawingWithNoRelationsDto } from '../../app/web-api-client';
import { HttpClient } from '@angular/common/http';
import { Column } from '../../shared/types';
import { TableComponent } from '../../components/table/table.component';

@Component({
  selector: 'app-drawings',
  standalone: true,
  imports: [TableComponent],
  templateUrl: './drawings.component.html',
  styleUrl: './drawings.component.scss',
})
export class DrawingsComponent implements OnInit {
  drawings: DrawingWithNoRelationsDto[];
  cols: Column[] = [
    { field: 'number', header: 'Numer' },
    { field: 'name', header: 'Nazwa' },
    { field: 'drawingRevision', header: 'Rewizja' },
    { field: 'lot', header: 'Lot' },
    { field: 'block', header: 'Blok' },
    { field: 'section', header: 'Sekcja' },
    { field: 'stage', header: 'Etap' },
    { field: 'createdBy', header: 'Autor' },
  ];

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient
  ) {}

  ngOnInit() {
    const shipId = this.route.snapshot.params['shipId'];

    this.http
      .get<DrawingWithNoRelationsDto[]>('/api/Drawings/GetAll', {
        params: {
          ShipId: shipId,
        },
      })
      .subscribe({
        next: (x) => {
          this.drawings = x;
        },
      });
  }
}
