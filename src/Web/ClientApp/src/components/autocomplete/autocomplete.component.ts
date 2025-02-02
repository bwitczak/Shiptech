import { Component, Input } from '@angular/core';
import { AutoComplete, AutoCompleteCompleteEvent } from 'primeng/autocomplete';
import { IftaLabel } from 'primeng/iftalabel';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-autocomplete',
  standalone: true,
  imports: [AutoComplete, IftaLabel, ReactiveFormsModule, FormsModule],
  templateUrl: './autocomplete.component.html',
  styleUrl: './autocomplete.component.scss',
})
export class AutocompleteComponent<T> {
  @Input() label: string;
  @Input() items: T[];
  @Input() formGroup: FormGroup;
  @Input() formPropertyName: string;
  @Input() optionLabel: T extends string ? never : Extract<keyof T, string>;
  @Input() searchFunction: (query: string) => Observable<T[]>;

  value: T;

  onSearch(event: AutoCompleteCompleteEvent) {
    this.searchFunction(event.query).subscribe({
      next: (results) => {
        this.items = results;
      },
    });
  }
}
