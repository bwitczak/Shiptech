import { Component, Input } from '@angular/core';
import { InputTextModule } from 'primeng/inputtext';
import {
  ControlContainer,
  FormGroup,
  FormGroupDirective,
  ReactiveFormsModule,
} from '@angular/forms';
import { IftaLabel } from 'primeng/iftalabel';

@Component({
  selector: 'app-input',
  standalone: true,
  imports: [InputTextModule, ReactiveFormsModule, IftaLabel],
  templateUrl: './input.component.html',
  styleUrl: './input.component.scss',
  viewProviders: [
    { provide: ControlContainer, useExisting: FormGroupDirective },
  ],
})
export class InputComponent {
  @Input() label: string;
  @Input() formGroup: FormGroup;
  @Input() formPropertyName: string;
}
