import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateOrden, OrdenReposicion } from '../models/orden.model';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class OrdenesService {
  private readonly baseUrl = `${environment.apiUrl}/ordenes`;

  constructor(private http: HttpClient) { }

  createOrden(orden: CreateOrden): Observable<OrdenReposicion> {
    return this.http.post<OrdenReposicion>(this.baseUrl, orden);
  }
}
