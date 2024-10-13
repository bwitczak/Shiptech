import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DrawingWithNoRelationsDto } from '../../app/web-api-client';
import { HttpClient } from '@angular/common/http';
import { Column } from '../../shared/types';
import { TableComponent } from '../../components/table/table.component';
import { BreadcrumbComponent } from '../../components/breadcrumb/breadcrumb.component';
import { MenuItem } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ErrorHandlingService } from '../../forms/errorHandlingService';
import { Select } from 'primeng/select';

@Component({
  selector: 'app-drawings',
  standalone: true,
  imports: [
    TableComponent,
    BreadcrumbComponent,
    ButtonModule,
    DialogModule,
    ReactiveFormsModule,
    Select,
  ],
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
  shipCode = '';
  navigation: MenuItem[];
  visible: boolean;

  drawingForm = new FormGroup({
    number: new FormControl(''),
    name: new FormControl(''),
    revision: new FormControl(''),
    lot: new FormControl(''),
    block: new FormControl(''),
    section: new FormControl('', Validators.pattern(/^\d+(?:,\s\d+)*$/)),
    stage: new FormControl(''),
  });

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    private errorHandlingService: ErrorHandlingService
  ) {
    this.actionButtonRedirect = this.actionButtonRedirect.bind(this);
  }

  ngOnInit() {
    this.shipCode = this.route.snapshot.params['shipCode'];
    this.navigation = [
      { icon: 'pi pi-home', route: '/' },
      { label: `Rysunek(${this.shipCode})` },
    ];

    this.http
      .get<DrawingWithNoRelationsDto[]>('/api/Drawings/GetAll', {
        params: {
          ShipCode: this.shipCode,
        },
      })
      .subscribe({
        next: (x) => {
          this.drawings = x;
        },
      });
  }

  addNewDrawing() {
    console.log(this.drawingForm.get('section')?.errors);
    this.http
      .post('/api/Drawings/Create', {
        ...this.drawingForm.value,
        section: [this.drawingForm.value.section],
        shipCode: this.shipCode,
      })
      .subscribe({
        error: (error) => {
          console.log(error);
          this.errorHandlingService.handleApiErrors(error, this.drawingForm);
        },
      });
  }

  actionButtonRedirect(number: string) {
    return `/isos/${number}?shipCode=${this.shipCode}`;
  }

  toggleAddDrawingDialog() {
    this.visible = true;
  }
}
