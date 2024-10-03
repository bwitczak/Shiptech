import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DrawingWithNoRelationsDto } from '../../app/web-api-client';
import { HttpClient } from '@angular/common/http';
import { Column } from '../../shared/types';
import { TableComponent } from '../../components/table/table.component';
import { BreadcrumbComponent } from '../../components/breadcrumb/breadcrumb.component';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-drawings',
  standalone: true,
  imports: [TableComponent, BreadcrumbComponent],
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
  filterFields = this.cols.map((x) => x.field);
  shipOrderer = '';
  navigation: MenuItem[];

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient
  ) {
    this.actionButtonRedirect = this.actionButtonRedirect.bind(this);
  }

  ngOnInit() {
    this.shipOrderer = this.route.snapshot.params['shipOrderer'];
    this.navigation = [
      { icon: 'pi pi-home', route: '/' },
      { label: `Rysunek(${this.shipOrderer})` },
    ];

    this.http
      .get<DrawingWithNoRelationsDto[]>('/api/Drawings/GetAll', {
        params: {
          ShipOrderer: this.shipOrderer,
        },
      })
      .subscribe({
        next: (x) => {
          this.drawings = x;
        },
      });
  }

  actionButtonRedirect(number: string) {
    return `/isos/${number}?shipOrderer=${this.shipOrderer}`;
  }
}
