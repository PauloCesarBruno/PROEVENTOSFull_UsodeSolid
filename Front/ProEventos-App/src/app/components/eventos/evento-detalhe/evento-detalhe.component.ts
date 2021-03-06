import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { Evento } from '@app/model/Evento';
import { EventoService } from '@app/services/evento.service';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})
export class EventoDetalheComponent implements OnInit {

  evento ={} as Evento;
  form: FormGroup | any;
  estadoSalvar = 'post';

  get f(): any {
    return this.form.controls;
  }

  get bsConfig(): any {
    return {

      dateInputFormat: 'DD/MM/YYYY hh:mm a',
      containerClass: 'theme-default',
      adaptivePSosition: true,
      showWeekNumbers: false,
      isAnimated: true
    }
  }

  constructor(private fb: FormBuilder,
              private localeService: BsLocaleService,
              private router: ActivatedRoute,
              private eventoService: EventoService,
              private spinner: NgxSpinnerService,
              private toastr: ToastrService)
   {
       this.localeService.use('pt-br');
   }

   public validation(): void {

    this.form = this.fb.group({
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
      telefone: ['', Validators.required],
      email: ['',[Validators.required, Validators.email]],
      imagemURL: ['', Validators.required],
    });
  }

   public carregarEvento(): void {
     const eventoIdParam =  this.router.snapshot.paramMap.get('id');

     if (eventoIdParam !== null ) {
        this.spinner.show();

         this.estadoSalvar = 'put'

        // Sinal de  "+"  converte p/ string.
        this.eventoService.getEventoById(+eventoIdParam).subscribe(
          (evento: Evento) => {
            this.evento = {...evento};
            this.form.patchValue(this.evento);
          },
          (erros: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao tentar carregar evento !', 'Erro!');
            console.error(erros);
          },
          () => this.spinner.hide(),
        );
     }
   }

  ngOnInit(): void {
    this.carregarEvento();
    this.validation();
  }

  public resetForm(): void {
    this.form.reset();
  }

  public cssValidator(campoForm: FormControl): any {
    return {'is-invalid': campoForm.errors && campoForm.touched }
  }

  public salvarAlteracao(): void {
    this.spinner.show();
    if (this.form.valid) {


      if (this.estadoSalvar === 'post') {
        this.evento = {...this.form.value};
        this.eventoService.postEvento(this.evento).subscribe(
          () => this.toastr.success('Evento salvo com sucesso !', 'Sucesso'),
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao tentar alterar evento!', 'Erro');
          },
          () => this.spinner.hide()
        );
      } else {
        this.evento = {id: this.evento.id, ...this.form.value};
        this.eventoService.putEvento(this.evento.id, this.evento).subscribe(
          () => this.toastr.success('Evento salvo com sucesso !', 'Sucesso'),
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao tentar alterar evento!', 'Erro');
          },
          () => this.spinner.hide()
           );
         }
        }
      }
    }
