import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function sectionFormatValidator(errorMessage: string): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const isValid = /^(?:\d+(?:,\s\d+)*)?$/.test(control.value);

    if (!isValid) {
      return {
        businessLogicError: errorMessage,
      };
    }

    return null;
  };
}
