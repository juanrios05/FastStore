export interface CreateOrden {
  productoId: number;
  cantidad: number;
}
export interface OrdenReposicion {
  id: number;
  productoId: number;
  fechaSolicitud: string;
  cantidad: number;
  estado: string;
}
