import {
  AfterViewInit,
  Component,
  OnDestroy,
  OnInit,
  TemplateRef,
  ViewChild,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IsoDto, IsosClient } from '../../app/web-api-client';
import { Column } from '../../shared/types';
import { TableComponent } from '../../components/table/table.component';
import { MenuItem } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { House, LucideAngularModule, Plus } from 'lucide-angular';
import { TopBarService } from '../../services/topBarService';

@Component({
  selector: 'app-isos',
  standalone: true,
  imports: [TableComponent, ButtonModule, LucideAngularModule],
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
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  @ViewChild('topBarContent') topBarContent!: TemplateRef<any>;
  // TODO: Check is could be not any type
  protected readonly Plus = Plus;

  constructor(
    private route: ActivatedRoute,
    private isoHttp: IsosClient,
    private topBarService: TopBarService
  ) {}

  ngOnInit() {
    const drawingNumber = this.route.snapshot.params['drawingNumber'];
    const shipCode = this.route.snapshot.queryParams['shipCode'];
    // this.navigation = [
    //   // { icon: 'pi pi-home', route: '/' },
    //   { label: `Rysunek(${shipCode})`, route: `/drawings/${shipCode}` },
    //   { label: `Iso(${drawingNumber})` },
    // ];
    this.topBarService.setBreadcrumbItems([
      { label: '', icon: House, link: '/' },
      { label: `Rysunek(${shipCode})`, link: `/drawings/${shipCode}` },
      { label: `Iso(${drawingNumber})` },
    ]);

    this.isoHttp.getAllIsos(drawingNumber).subscribe({
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

  toggleAddIsoDialog() {
    return null;
  }
}
