import {
  AfterViewInit,
  Component,
  OnDestroy,
  OnInit,
  TemplateRef,
  ViewChild,
} from '@angular/core';
import { Button } from 'primeng/button';
import { House, LucideAngularModule, Plus } from 'lucide-angular';
import { TableComponent } from '../../components/table/table.component';
import { Column } from '../../shared/types';
import {
  AssortmentClient,
  AssortmentDictionariesClient,
  AssortmentDto,
} from '../../app/web-api-client';
import { ActivatedRoute } from '@angular/router';
import { ErrorHandlingService } from '../../forms/errorHandlingService';
import { TopBarService } from '../../services/topBarService';
import { DialogComponent } from '../../components/dialog/dialog.component';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { InputComponent } from '../../components/input/input.component';
import { SelectComponent } from '../../components/select/select.component';
import { AutocompleteComponent } from '../../components/autocomplete/autocomplete.component';

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
  assortmentForm = new FormGroup({
    standardNumber: new FormControl(''),
    position: new FormControl(''),
    prefabricationQuantity: new FormControl(''),
    prefabricationLength: new FormControl(''),
    prefabricationWeight: new FormControl(''),
    assemblyQuantity: new FormControl(''),
    assemblyLength: new FormControl(''),
    assemblyWeight: new FormControl(''),
    pg: new FormControl(''),
    valveNumber: new FormControl(''),
    cutAngle: new FormControl(''),
    comment: new FormControl(''),
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
