import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  // providers: [EventoService] - >poderia ser injetado aqui além de lá no Evento,Service ou App.Module...
})
export class EventosComponent implements OnInit {

  ngOnInit(): void {

  }
}
