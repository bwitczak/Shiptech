import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IsoDto, IsosClient } from '../../app/web-api-client';
import { Column } from '../../shared/types';
import { TableComponent } from '../../components/table/table.component';
import { MenuItem } from 'primeng/api';
import { BreadcrumbComponent } from '../../components/breadcrumb/breadcrumb.component';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-isos',
  standalone: true,
  imports: [TableComponent, BreadcrumbComponent, ButtonModule],
  templateUrl: './isos.component.html',
  styleUrl: './isos.component.scss',
})
export class IsosComponent implements OnInit {
  isos: IsoDto[];
  cols: Column[] = [
    { field: 'number', header: 'Numer' },
    { field: 'nameplate', header: 'Tabliczka znamionowa' },
    { field: 'isoRevision', header: 'Rewizja' },
    { field: 'system', header: 'System' },
    { field: 'class', header: 'Klasa' },
    { field: 'atest', header: 'Atest' },
    { field: 'kzmNumber', header: 'Numer KZM' },
    { field: 'kzmDate', header: 'Data KZM' },
    {
      field: 'chemicalProcess',
      subfield: 'chemicalProcessName',
      header: 'Obróbka chemiczna',
    },
  ];
  navigation: MenuItem[];

  constructor(
    private route: ActivatedRoute,
    private isoHttp: IsosClient
  ) {}

  ngOnInit() {
    const drawingNumber = this.route.snapshot.params['drawingNumber'];
    const shipCode = this.route.snapshot.queryParams['shipCode'];
    this.navigation = [
      { icon: 'pi pi-home', route: '/' },
      { label: `Rysunek(${shipCode})`, route: `/drawings/${shipCode}` },
      { label: `Iso(${drawingNumber})` },
    ];

    this.isoHttp.getAllIsos(drawingNumber).subscribe({
      next: (x) => {
        this.isos = x;
      },
    });
  }
}
