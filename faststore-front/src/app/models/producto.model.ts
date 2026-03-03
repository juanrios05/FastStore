export interface Producto {
  id: number;
  nombre: string;
  precio: number;
  stockActual: number;
  stockMinimo: number;
  categoriaId: number;
  categoriaNombre: string;
  stockCritico: boolean;
}
