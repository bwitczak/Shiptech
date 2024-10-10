import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class ErrorHandlingService {
  handleApiErrors(error: HttpErrorResponse, form: FormGroup): void {
    if (error.status === 400 && error.error && error.error.errors) {
      const serverErrors = error.error.errors;
      Object.keys(serverErrors).forEach((key) => {
        const formControl = this.getFormControl(form, key);
        if (formControl) {
          formControl.setErrors({
            serverError: serverErrors[key][0],
          });
        }
      });
    }
  }

  // TODO: Check is could be not any type
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  private getFormControl(form: FormGroup, key: string): any {
    const keyParts = key.split('[');
    if (keyParts.length === 1) {
      return form.get(key);
    } else {
      const controlName = keyParts[0];
      const index = parseInt(keyParts[1].replace(']', ''), 10);
      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      const formArray = form.get(controlName) as any;
      return formArray.controls[index];
    }
  }
}
