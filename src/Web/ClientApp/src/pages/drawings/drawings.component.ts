import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
  CreateDrawingCommand,
  DrawingsClient,
  DrawingWithNoRelationsDto,
} from '../../app/web-api-client';
import { Column } from '../../shared/types';
import { TableComponent } from '../../components/table/table.component';
import { BreadcrumbComponent } from '../../components/breadcrumb/breadcrumb.component';
import { MenuItem } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ErrorHandlingService } from '../../forms/errorHandlingService';
import { Select } from 'primeng/select';
import { InputTextModule } from 'primeng/inputtext';
import { InputComponent } from '../../components/input/input.component';
import { sectionFormatValidator } from '../../shared/customValidators';
import { SelectComponent } from '../../components/select/select.component';

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
    InputTextModule,
    InputComponent,
    SelectComponent,
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
    section: new FormControl(
      '',
      sectionFormatValidator(
        'Nieprawidłowy format. Wartość powinna składać się z liczb całkowitych\n' +
          '          oddzielonych przecinkiem i spacją (np. 142, 770, 381)'
      )
    ),
    stage: new FormControl(''),
  });
  stageOptions: string[] = ['ODP', 'ODS', 'ODI'];

  constructor(
    private route: ActivatedRoute,
    private drawingHttp: DrawingsClient,
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

    this.drawingHttp.getAllDrawings(this.shipCode).subscribe({
      next: (x) => {
        this.drawings = x;
      },
    });
  }

  addNewDrawing() {
    const drawing: CreateDrawingCommand = {
      ...this.drawingForm.value,
      section: [this.drawingForm.value.section],
      shipCode: this.shipCode,
    } as CreateDrawingCommand;

    this.drawingHttp.createDrawing(drawing).subscribe({
      error: (error) => {
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
