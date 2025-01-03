import { Component, Input } from '@angular/core';
import { InputTextModule } from 'primeng/inputtext';
import {
  ControlContainer,
  FormGroup,
  FormGroupDirective,
  ReactiveFormsModule,
} from '@angular/forms';
import { Select } from 'primeng/select';
import { IftaLabel } from 'primeng/iftalabel';

@Component({
  selector: 'app-select',
  standalone: true,
  imports: [InputTextModule, ReactiveFormsModule, Select, IftaLabel],
  templateUrl: './select.component.html',
  styleUrl: './select.component.scss',
  viewProviders: [
    { provide: ControlContainer, useExisting: FormGroupDirective },
  ],
})
export class SelectComponent {
  @Input() label: string;
  @Input() formGroup: FormGroup;
  @Input() formPropertyName: string;
  @Input() options: string[];
}
