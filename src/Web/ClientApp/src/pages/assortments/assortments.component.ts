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
import { AssortmentClient, AssortmentDto } from '../../app/web-api-client';
import { ActivatedRoute } from '@angular/router';
import { ErrorHandlingService } from '../../forms/errorHandlingService';
import { TopBarService } from '../../services/topBarService';

@Component({
  selector: 'app-assortments',
  standalone: true,
  imports: [Button, LucideAngularModule, TableComponent],
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

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  @ViewChild('topBarContent') topBarContent!: TemplateRef<any>;
  visible: boolean;

  // TODO: Check is could be not any type
  protected readonly Plus = Plus;

  constructor(
    private route: ActivatedRoute,
    private assortmentClient: AssortmentClient,
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

  toggleAddAssortmentDialog() {
    this.visible = true;
  }
}
