import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Producto } from '../../models/producto.model';
import { InventarioService } from '../../services/inventario.service';
import { ReponerModalComponent } from '../reponer-modal/reponer-modal.component';

@Component({
  selector: 'app-tabla-inventario',
  standalone: true,
  imports: [CommonModule, FormsModule, ReponerModalComponent],
  templateUrl: './tabla-inventario.component.html',
  styleUrls: ['./tabla-inventario.component.css']
})
export class TablaInventarioComponent implements OnInit {
  productos: Producto[] = [];
  productosFiltrados: Producto[] = [];
  busqueda = '';
  cargando = true;
  errorCarga = '';
  soloLowStock = false;

  productoSeleccionado: Producto | null = null;
  toastMsg = '';
  private toastTimer: any;

  constructor(private inventarioService: InventarioService) { }

  ngOnInit(): void {
    this.cargarProductos();
  }

  cargarProductos(): void {
    this.cargando = true;
    this.errorCarga = '';
    this.inventarioService.getAll().subscribe({
      next: (data) => {
        this.productos = data;
        this.productosFiltrados = [...data];
        this.cargando = false;
      },
      error: (err) => {
        console.error('Error al cargar productos:', err);
        this.errorCarga = `Error ${err.status}: No se pudieron cargar los productos.`;
        this.cargando = false;
      }
    });
  } 

  verLowStock() {
    this.soloLowStock = true;
    this.actualizarVista();
  }

  verTodos() {
    this.soloLowStock = false;
    this.actualizarVista();
  }

  aplicarFiltro() {
    this.actualizarVista();
  }   

  private actualizarVista(): void {
    let resultado = [...this.productos];

    if (this.soloLowStock) {
      resultado = resultado.filter(p => p.stockCritico);
    }

    if (this.busqueda.trim()) {
      const termino = this.busqueda.toLowerCase();
      resultado = resultado.filter(p =>
        p.nombre.toLowerCase().includes(termino)
      );
    }

    this.productosFiltrados = resultado;
  }

  abrirModal(producto: Producto): void {
    this.productoSeleccionado = producto;
  }

  cerrarModal(): void {
    this.productoSeleccionado = null;
  }

  onExitoOrden(mensaje: string): void {
    this.toastMsg = mensaje;
    clearTimeout(this.toastTimer);
    this.toastTimer = setTimeout(() => (this.toastMsg = ''), 4000);
  }

  formatPrecio(precio: number): string {
    return new Intl.NumberFormat('es-CO', {
      style: 'currency',
      currency: 'COP',
      maximumFractionDigits: 0
    }).format(precio);
  }
}
