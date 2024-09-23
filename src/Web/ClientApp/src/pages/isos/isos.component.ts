import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IsoDto } from '../../app/web-api-client';
import { HttpClient } from '@angular/common/http';
import { Column } from '../../shared/types';
import { TableComponent } from '../../components/table/table.component';

@Component({
  selector: 'app-isos',
  standalone: true,
  imports: [TableComponent],
  templateUrl: './isos.component.html',
  styleUrl: './isos.component.scss',
})
export class IsosComponent implements OnInit {
  isos: IsoDto[];
  cols: Column[] = [
    { field: 'number', header: 'Numer' },
    { field: 'nameplate', header: 'Tabliczka znamionowa' },
    { field: 'isoRevision', header: 'Rewizja' },
    { field: 'lot', header: 'Lot' },
    { field: 'block', header: 'Blok' },
    { field: 'section', header: 'Sekcja' },
    { field: 'stage', header: 'Etap' },
    { field: 'system', header: 'System' },
    { field: 'class', header: 'Klasa' },
    { field: 'atest', header: 'Atest' },
    { field: 'kzmNumber', header: 'Numer KZM' },
    { field: 'kzmDate', header: 'Data KZM' },
    {
      field: 'chemicalProcess.chemicalProcessName',
      header: 'Obróbka chemiczna',
    },
  ];
  filterFields = this.cols.map((x) => x.field);

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient
  ) {}

  ngOnInit() {
    const drawingId = this.route.snapshot.params['drawingId'];

    this.http
      .get<IsoDto[]>('/api/Isos/GetAll', {
        params: {
          DrawingId: drawingId,
        },
      })
      .subscribe({
        next: (x) => {
          this.isos = x;
        },
      });
  }
}
