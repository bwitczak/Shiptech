// @ts-expect-error Ignore Lucide Icon type definition
import { LucideIconData } from 'lucide-angular/icons/types';

export interface Column {
  header: string;
  field: string;
  subfield?: string;
}

export interface BreadcrumbItem {
  label: string;
  icon?: LucideIconData;
  link?: string;
}
