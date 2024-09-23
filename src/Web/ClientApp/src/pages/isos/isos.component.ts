import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IsoDto } from '../../app/web-api-client';
import { HttpClient } from '@angular/common/http';
import { Column } from '../../shared/types';
import { TableComponent } from '../../components/table/table.component';
import { MenuItem } from 'primeng/api';
import { BreadcrumbComponent } from '../../components/breadcrumb/breadcrumb.component';

@Component({
  selector: 'app-isos',
  standalone: true,
  imports: [TableComponent, BreadcrumbComponent],
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
  navigation: MenuItem[];

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient
  ) {}

  ngOnInit() {
    const drawingNumber = this.route.snapshot.params['drawingNumber'];
    const shipId = this.route.snapshot.queryParams['shipId'];
    this.navigation = [
      { icon: 'pi pi-home', route: '/' },
      { label: 'Rysunek', route: `/drawings/${shipId}` },
      { label: `Iso(${drawingNumber})` },
    ];

    this.http
      .get<IsoDto[]>('/api/Isos/GetAll', {
        params: {
          DrawingNumber: drawingNumber,
        },
      })
      .subscribe({
        next: (x) => {
          this.isos = x;
        },
      });
  }
}
