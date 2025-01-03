import {
  AfterViewInit,
  Component,
  OnDestroy,
  OnInit,
  TemplateRef,
  ViewChild,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CreateIsoCommand, IsoDto, IsosClient } from '../../app/web-api-client';
import { Column } from '../../shared/types';
import { TableComponent } from '../../components/table/table.component';
import { MenuItem } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { House, LucideAngularModule, Plus } from 'lucide-angular';
import { TopBarService } from '../../services/topBarService';
import { DialogComponent } from '../../components/dialog/dialog.component';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { InputComponent } from '../../components/input/input.component';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { SelectComponent } from '../../components/select/select.component';
import { ErrorHandlingService } from '../../forms/errorHandlingService';

@Component({
  selector: 'app-isos',
  standalone: true,
  imports: [
    TableComponent,
    ButtonModule,
    DialogModule,
    ReactiveFormsModule,
    InputTextModule,
    InputComponent,
    LucideAngularModule,
    DialogComponent,
    FormsModule,
    SelectComponent,
  ],
  templateUrl: './isos.component.html',
  styleUrl: './isos.component.scss',
})
export class IsosComponent implements OnInit, AfterViewInit, OnDestroy {
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
  drawingNumber = '';
  shipCode = '';
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  @ViewChild('topBarContent') topBarContent!: TemplateRef<any>;
  visible: boolean;
  isoForm = new FormGroup({
    number: new FormControl(''),
    nameplate: new FormControl(''),
    revision: new FormControl(''),
    system: new FormControl(''),
    class: new FormControl(''),
    atest: new FormControl(''),
    kzmNumber: new FormControl(''),
    kzmDate: new FormControl(''),
    chemicalProcessName: new FormControl(''),
  });

  // TODO: Fetch from API
  atestOptions: string[] = [
    'tak',
    '/C',
    'C/C',
    '/W',
    'W/C',
    'W/W',
    'MC',
    'MD',
    'MTR',
  ];

  // TODO: Fetch from API
  chemicalProcessesOptions: string[] = [
    'cynkowanie',
    'cynkowanie wewnątrz',
    'fosforowanie',
    'fosforowanie i olejowanie',
    'gumowanie',
    'malowanie',
    'malowanie farbą chlorową',
    'malowanie na zewn. farbą epoksydową',
    'malowanie wewn. 2',
    'malowanie wewn. 4',
    'M1-P',
    'NM1-0',
  ];

  // TODO: Check is could be not any type
  protected readonly Plus = Plus;

  constructor(
    private route: ActivatedRoute,
    private isoHttp: IsosClient,
    private errorHandlingService: ErrorHandlingService,
    private topBarService: TopBarService
  ) {}

  ngOnInit() {
    this.drawingNumber = this.route.snapshot.params['drawingNumber'];
    this.shipCode = this.route.snapshot.queryParams['shipCode'];
    this.topBarService.setBreadcrumbItems([
      { label: '', icon: House, link: '/' },
      {
        label: `Rysunek(${this.shipCode})`,
        link: `/drawings/${this.shipCode}`,
      },
      { label: `Iso(${this.drawingNumber})` },
    ]);

    this.isoHttp.getAllIsos(this.drawingNumber).subscribe({
      next: (x) => {
        this.isos = x;
      },
    });
  }

  ngAfterViewInit() {
    this.topBarService.setContent(this.topBarContent);
  }

  ngOnDestroy() {
    this.topBarService.clearContent();
  }

  addNewIso() {
    const iso: CreateIsoCommand = {
      ...this.isoForm.value,
      drawingNumber: this.drawingNumber,
    } as CreateIsoCommand;

    this.isoHttp.createIso(iso).subscribe({
      error: (error) => {
        this.errorHandlingService.handleApiErrors(error, this.isoForm);
      },
    });
  }

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  actionButtonRedirect(number: string, params?: any) {
    const baseUrl = `/assortments/${number}`;
    const queryParams = new URLSearchParams(params).toString();

    return `${baseUrl}?${queryParams}`;
  }

  toggleAddIsoDialog() {
    this.visible = true;
  }
}
