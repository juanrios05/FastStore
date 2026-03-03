import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Producto } from '../../models/producto.model';
import { OrdenesService } from '../../services/ordenes.service';

@Component({
  selector: 'app-reponer-modal',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './reponer-modal.component.html',
  styleUrls: ['./reponer-modal.component.css']
})
export class ReponerModalComponent implements OnInit {
  @Input() producto!: Producto;
  @Output() cerrar = new EventEmitter<void>();
  @Output() exito = new EventEmitter<string>();

  form!: FormGroup;
  cargando = false;
  errorMsg = '';

  constructor(
    private fb: FormBuilder,
    private ordenesService: OrdenesService
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      cantidad: [null, [Validators.required, Validators.min(1)]]
    });
  }

  confirmar(): void {
    if (this.form.invalid) return;

    this.cargando = true;
    this.errorMsg = '';

    this.ordenesService.createOrden({
      productoId: this.producto.id,
      cantidad: this.form.value.cantidad
    }).subscribe({
      next: () => {
        this.cargando = false;
        this.exito.emit(`✅ Orden de reposición creada para "${this.producto.nombre}"`);
        this.cerrar.emit();
      },
      error: (err) => {
        this.cargando = false;
        this.errorMsg = err.error?.message || 'Error al crear la orden. Intenta de nuevo.';
      }
    });
  }

  cancelar(): void {
    this.cerrar.emit();
  }
}
