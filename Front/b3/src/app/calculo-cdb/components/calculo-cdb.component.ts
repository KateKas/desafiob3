import { Component, OnInit } from "@angular/core";
import { ReactiveFormsModule, FormControl, FormGroup, Validators } from "@angular/forms";
import { CDBService } from "../services/cdb.services";

import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { CDB } from "../models/cdb.models";
import { UtilsService } from "../../core/shared/form/utils.service";

@Component({
    selector: 'app-calculo-cdb',
    templateUrl: './calculo-cdb.component.html',
    styleUrls: ['./calculo-cdb.component.css'],
    standalone: true,
    imports: [
        MatCardModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatSnackBarModule
    ],
})
export class calculoCDBComponent implements OnInit {

    cDBForm!: FormGroup;
    constructor(
        private cDBService: CDBService,
        protected formUtils: UtilsService,
        private snackBar: MatSnackBar) { }


    ngOnInit(): void {
        this.inicializarFrom();
    }

    inicializarFrom() {
        this.cDBForm = new FormGroup({
            valorInicial: new FormControl('', [Validators.required, Validators.min(1)]),
            prazo: new FormControl('', [Validators.required, Validators.min(1),
            Validators.max(360),])
        });
    }

    calcular() {

        if (this.cDBForm.valid) {
            this.cDBService.CalculoCDB(this.cDBForm.value as CDB).subscribe({
                next: (data) => {
                    this.snackBar.open(`CDB calculado com sucesso! \n Valor Bruto: R$ ${data.valorBruto.toFixed(2)}
                        \n Valor Liquido: R$ ${data.valorLiquido.toFixed(2)}`, 'Fechar', {
                        panelClass: ['success-snackbar'],
                        verticalPosition: 'top'
                    });
                },
                error: (error) => {
                    this.snackBar.open(`Erro ao calcular CDB!`, 'Fechar', {
                        duration: 5000,
                        verticalPosition: 'top'
                    });
                }
            });
        } else {
            this.formUtils.validateAllFormFields(this.cDBForm);
        }
    }
}       