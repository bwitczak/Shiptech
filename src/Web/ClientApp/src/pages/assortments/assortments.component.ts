import { CommonModule } from '@angular/common';
import {
  AfterViewInit,
  Component,
  OnDestroy,
  OnInit,
  TemplateRef,
  ViewChild,
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { House, LucideAngularModule, Plus } from 'lucide-angular';
import { Button } from 'primeng/button';
import {
  AssortmentClient,
  AssortmentDictionariesClient,
  AssortmentDto,
  IAssortmentDictionaryDto,
} from '../../app/web-api-client';
import { AutocompleteComponent } from '../../components/autocomplete/autocomplete.component';
import { DialogComponent } from '../../components/dialog/dialog.component';
import { InputComponent } from '../../components/input/input.component';
import { SelectComponent } from '../../components/select/select.component';
import { TableComponent } from '../../components/table/table.component';
import { ErrorHandlingService } from '../../forms/errorHandlingService';
import { TopBarService } from '../../services/topBarService';
import { Column } from '../../shared/types';

interface AssortmentForm {
  standardNumber: FormControl<IAssortmentDictionaryDto | null>;
  position: FormControl<string>;
  prefabricationQuantity: FormControl<number>;
  prefabricationLength: FormControl<number>;
  prefabricationWeight: FormControl<number>;
  assemblyQuantity: FormControl<number>;
  assemblyLength: FormControl<number>;
  assemblyWeight: FormControl<number>;
  pg: FormControl<string>;
  valveNumber?: FormControl<string | undefined>;
  cutAngle?: FormControl<string | undefined>;
  comment?: FormControl<string | undefined>;
}

@Component({
  selector: 'app-assortments',
  standalone: true,
  imports: [
    Button,
    LucideAngularModule,
    TableComponent,
    DialogComponent,
    FormsModule,
    ReactiveFormsModule,
    InputComponent,
    SelectComponent,
    AutocompleteComponent,
    CommonModule,
  ],
  templateUrl: './assortments.component.html',
  styleUrl: './assortments.component.scss',
})
export class AssortmentsComponent implements OnInit, AfterViewInit, OnDestroy {
  assortments: AssortmentDto[];
  cols: Column[] = [
    { field: 'position', header: 'Pozycja' },
    { field: 'prefabricationQuantity', header: 'Ilość (prefabrykacja)' },
    { field: 'prefabricationLength', header: 'Długość (prefabrykacja)' },
    { field: 'prefabricationWeight', header: 'Waga (prefabrykacja)' },
    { field: 'assemblyQuantity', header: 'Ilość (montaż)' },
    { field: 'assemblyLength', header: 'Długość (montaż)' },
    { field: 'assemblyWeight', header: 'Waga (montaż)' },
    { field: 'pg', header: 'P/G' },
    { field: 'valveNumber', header: 'Numer zaworu' },
    { field: 'cutAngle', header: 'Kąt cięcia' },
    { field: 'comment', header: 'Komentarz' },
  ];
  shipCode = '';
  drawingNumber = '';
  isoNumber = '';

  // TODO: Fetch from API
  cutAngleOptions: string[] = [
    '0° - 1°',
    '1° - 1°',
    '0° - 1,5°',
    '1,5° - 1,5°',
    '0° - 2°',
    '2° - 2°',
    '0° - 2,5°',
    '2,5° - 2,5°',
    '0° - 30°',
    '30° - 30°',
    '0° - 45°',
    '45° - 45°',
  ];

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  @ViewChild('topBarContent') topBarContent!: TemplateRef<any>;
  visible: boolean;
  assortmentForm = new FormGroup<AssortmentForm>({
    standardNumber: new FormControl(null),
    position: new FormControl('', { nonNullable: true }),
    prefabricationQuantity: new FormControl(0, { nonNullable: true }),
    prefabricationLength: new FormControl(0, { nonNullable: true }),
    prefabricationWeight: new FormControl(0, { nonNullable: true }),
    assemblyQuantity: new FormControl(0, { nonNullable: true }),
    assemblyLength: new FormControl(0, { nonNullable: true }),
    assemblyWeight: new FormControl(0, { nonNullable: true }),
    pg: new FormControl('', { nonNullable: true }),
    valveNumber: new FormControl('', { nonNullable: true }),
    cutAngle: new FormControl('', { nonNullable: true }),
    comment: new FormControl('', { nonNullable: true }),
  });

  // TODO: Check is could be not any type
  protected readonly Plus = Plus;

  constructor(
    private route: ActivatedRoute,
    private assortmentClient: AssortmentClient,
    private assortmentDictionaryClient: AssortmentDictionariesClient,
    private errorHandlingService: ErrorHandlingService,
    private topBarService: TopBarService
  ) {}

  ngOnInit() {
    this.isoNumber = this.route.snapshot.params['isoNumber'];
    this.shipCode = this.route.snapshot.queryParams['shipCode'];
    this.drawingNumber = this.route.snapshot.queryParams['drawingNumber'];

    this.topBarService.setBreadcrumbItems([
      { label: '', icon: House, link: '/' },
      {
        label: `Rysunek(${this.shipCode})`,
        link: `/drawings/${this.shipCode}`,
      },
      {
        label: `Iso(${this.drawingNumber})`,
        link: `/isos/${this.drawingNumber}?shipCode=${this.shipCode}`,
      },
      { label: `Asortyment(${this.isoNumber})` },
    ]);

    this.assortmentClient.getAllAssortments(this.isoNumber).subscribe({
      next: (x) => {
        this.assortments = x;
      },
    });
  }

  ngAfterViewInit() {
    this.topBarService.setContent(this.topBarContent);
  }

  ngOnDestroy() {
    this.topBarService.clearContent();
  }

  addNewAssortment() {
    return null;
  }

  toggleAddAssortmentDialog() {
    this.visible = true;
  }

  assortmentDictionarySearch() {
    return (query: string) => {
      return this.assortmentDictionaryClient.searchAssortmentDictionaries(
        query
      );
    };
  }
}
