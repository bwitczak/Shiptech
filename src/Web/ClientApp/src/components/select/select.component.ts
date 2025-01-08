import { Component, Input } from '@angular/core';
import { InputTextModule } from 'primeng/inputtext';
import {
  ControlContainer,
  FormGroup,
  FormGroupDirective,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { Select } from 'primeng/select';
import { IftaLabel } from 'primeng/iftalabel';
import { LucideAngularModule } from 'lucide-angular';

@Component({
  selector: 'app-select',
  standalone: true,
  imports: [
    InputTextModule,
    ReactiveFormsModule,
    Select,
    IftaLabel,
    FormsModule,
    LucideAngularModule,
  ],
  templateUrl: './select.component.html',
  styleUrl: './select.component.scss',
  viewProviders: [
    { provide: ControlContainer, useExisting: FormGroupDirective },
  ],
})
export class SelectComponent<
  T extends string | Record<string, string | number | undefined | null>,
> {
  @Input() label: string;
  @Input() formGroup: FormGroup;
  @Input() formPropertyName: string;
  @Input() optionLabel: T extends string ? never : Extract<keyof T, string>;
  @Input() options: T[];
  selected: string | number | null = null;
}
