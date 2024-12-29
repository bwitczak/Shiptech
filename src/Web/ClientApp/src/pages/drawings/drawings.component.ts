import {
  AfterViewInit,
  Component,
  OnDestroy,
  OnInit,
  TemplateRef,
  ViewChild,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
  CreateDrawingCommand,
  DrawingsClient,
  DrawingWithNoRelationsDto,
} from '../../app/web-api-client';
import { Column } from '../../shared/types';
import { TableComponent } from '../../components/table/table.component';
import { MenuItem } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ErrorHandlingService } from '../../forms/errorHandlingService';
import { InputTextModule } from 'primeng/inputtext';
import { InputComponent } from '../../components/input/input.component';
import { sectionFormatValidator } from '../../shared/customValidators';
import { SelectComponent } from '../../components/select/select.component';
import { TopBarService } from '../../services/topBarService';
import { House, LucideAngularModule, Plus } from 'lucide-angular';
import { DialogComponent } from '../../components/dialog/dialog.component';

@Component({
  selector: 'app-drawings',
  standalone: true,
  imports: [
    TableComponent,
    ButtonModule,
    DialogModule,
    ReactiveFormsModule,
    InputTextModule,
    InputComponent,
    SelectComponent,
    LucideAngularModule,
    DialogComponent,
  ],
  templateUrl: './drawings.component.html',
  styleUrl: './drawings.component.scss',
})
export class DrawingsComponent implements OnInit, AfterViewInit, OnDestroy {
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
  // TODO: Check is could be not any type
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  @ViewChild('topBarContent') topBarContent!: TemplateRef<any>;
  readonly Plus = Plus;

  constructor(
    private route: ActivatedRoute,
    private drawingHttp: DrawingsClient,
    private errorHandlingService: ErrorHandlingService,
    private topBarService: TopBarService
  ) {
    this.actionButtonRedirect = this.actionButtonRedirect.bind(this);
  }

  ngOnInit() {
    this.shipCode = this.route.snapshot.params['shipCode'];

    this.topBarService.setBreadcrumbItems([
      { label: '', icon: House, link: '/' },
      { label: `Rysunek(${this.shipCode})` },
    ]);

    this.drawingHttp.getAllDrawings(this.shipCode).subscribe({
      next: (x) => {
        this.drawings = x;
      },
    });
  }

  ngAfterViewInit() {
    this.topBarService.setContent(this.topBarContent);
  }

  ngOnDestroy() {
    this.topBarService.clearContent();
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
