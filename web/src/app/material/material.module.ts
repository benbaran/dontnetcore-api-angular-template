import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatToolbarModule,
  MatAutocompleteModule, MatFormFieldModule, MatInputModule
 } from '@angular/material';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatButtonModule, MatToolbarModule,
    MatAutocompleteModule, MatFormFieldModule, MatInputModule
  ],
  exports: [
    MatButtonModule, MatToolbarModule,
    MatAutocompleteModule, MatFormFieldModule, MatInputModule
  ]
})
export class MaterialModule { }
