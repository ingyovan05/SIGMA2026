import { HttpClient } from '@angular/common/http';
import { Component, DestroyRef, computed, inject, OnInit, signal } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { environment } from '../../../environments/environment';
import { SystemModule } from '../../core/auth.models';
import { AuthService } from '../../core/auth.service';

@Component({
  selector: 'app-dashboard',
  imports: [RouterLink],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss'
})
export class Dashboard implements OnInit {
  private readonly http = inject(HttpClient);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly destroyRef = inject(DestroyRef);

  readonly auth = inject(AuthService);
  readonly modules = signal<SystemModule[]>([]);
  readonly selectedKey = signal('principal');
  readonly reportSearch = signal('');
  readonly selectedModule = computed(() =>
    this.modules().find(module => module.key === this.selectedKey()));

  readonly reports = [
    { group: 'Operación', name: 'Reporte diario de actividades', description: 'Consolidado de ejecución por fecha, base y contrato.' },
    { group: 'Personal', name: 'Personal activo por proyecto', description: 'Relación de personal, cargo y ubicación actual.' },
    { group: 'Compras', name: 'Seguimiento de órdenes de compra', description: 'Estado de solicitudes, aprobaciones y entregas.' },
    { group: 'Bodega', name: 'Existencias y movimientos', description: 'Saldos, entradas, salidas y transferencias de inventario.' },
    { group: 'SSTA', name: 'Indicadores SSTA', description: 'Resumen de indicadores de seguridad, salud y ambiente.' },
    { group: 'Activos', name: 'Inventario de activos fijos', description: 'Ubicación, responsable y estado de activos.' }
  ];

  ngOnInit(): void {
    this.route.paramMap.pipe(takeUntilDestroyed(this.destroyRef)).subscribe(params => {
      this.selectedKey.set(params.get('key') ?? 'principal');
    });

    this.http.get<SystemModule[]>(`${environment.apiUrl}/system/modules`)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: modules => {
          this.modules.set(modules);
          const selected = modules.find(module => module.key === this.selectedKey());
          if (this.selectedKey() !== 'principal' && (!selected || selected.status === 'planned')) {
            this.router.navigateByUrl('/');
          }
        }
      });
  }

  visibleReports(): typeof this.reports {
    const term = this.reportSearch().trim().toLocaleLowerCase();
    return term
      ? this.reports.filter(report =>
          `${report.group} ${report.name} ${report.description}`.toLocaleLowerCase().includes(term))
      : this.reports;
  }
}
