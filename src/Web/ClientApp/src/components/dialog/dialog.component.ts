import {
  Component,
  EventEmitter,
  Input,
  Output,
  WritableSignal,
} from '@angular/core';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-dialog',
  standalone: true,
  imports: [DialogModule, ButtonModule],
  templateUrl: './dialog.component.html',
  styleUrl: './dialog.component.scss',
})
export class DialogComponent {
  @Input() visible: boolean | WritableSignal<boolean>;
  // TODO: Check is could be not any type
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  @Input() styles: any;
  @Input() header: string;
  @Output() confirm = new EventEmitter<void>();
  @Output() visibleChange = new EventEmitter<boolean>();

  handleConfirm() {
    this.confirm.emit();
  }

  handleCancel() {
    this.visibleChange.emit(false);
  }

  toggleVisibility(visible: boolean) {
    this.visibleChange.emit(visible);
  }
}
