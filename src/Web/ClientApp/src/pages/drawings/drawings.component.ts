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
  shipId = '';
  navigation: MenuItem[];

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient
  ) {
    this.actionButtonRedirect = this.actionButtonRedirect.bind(this);
  }

  ngOnInit() {
    this.shipId = this.route.snapshot.params['shipId'];
    this.navigation = [
      { icon: 'pi pi-home', route: '/' },
      { label: `Rysunek(${this.shipId})` },
    ];

    this.http
      .get<DrawingWithNoRelationsDto[]>('/api/Drawings/GetAll', {
        params: {
          ShipId: this.shipId,
        },
      })
      .subscribe({
        next: (x) => {
          this.drawings = x;
        },
      });
  }

  actionButtonRedirect(number: string) {
    return `/isos/${number}?shipId=${this.shipId}`;
  }
}
