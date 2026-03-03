import { Component } from '@angular/core';
import { TablaInventarioComponent } from './components/tabla-inventario/tabla-inventario.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [TablaInventarioComponent],
  template: `<app-tabla-inventario />`
})
export class AppComponent { }
