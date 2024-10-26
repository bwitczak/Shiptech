import { Injectable, signal, TemplateRef } from '@angular/core';
import { BreadcrumbItem } from '../shared/types';

@Injectable({
  providedIn: 'root',
})
export class TopBarService {
  breadcrumbItems = signal<BreadcrumbItem[]>([]);
  // TODO: Check is could be not any type
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  contentSignal = signal<TemplateRef<any> | null>(null);

  getBreadcrumbItems() {
    return this.breadcrumbItems;
  }

  setBreadcrumbItems(breadcrumbItems: BreadcrumbItem[]) {
    this.breadcrumbItems.set(breadcrumbItems);
  }

  // TODO: Check is could be not any type
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  setContent(content: TemplateRef<any>) {
    this.contentSignal.set(content);
  }

  clearContent() {
    this.contentSignal.set(null);
  }
}
