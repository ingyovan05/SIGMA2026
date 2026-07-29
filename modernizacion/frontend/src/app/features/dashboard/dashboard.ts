import { HttpClient } from '@angular/common/http';
import { Component, DestroyRef, computed, inject, OnInit, signal } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { environment } from '../../../environments/environment';
import { SystemModule } from '../../core/auth.models';
import { AuthService } from '../../core/auth.service';

@Component({
  selector: 'app-dashboard',
  imports: [RouterLink, FormsModule],
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
  readonly people = signal<PersonSummary[]>([]);
  readonly selectedPerson = signal<PersonDetail | null>(null);
  readonly peopleLoading = signal(false);
  readonly cities = signal<LookupItem[]>([]);
  readonly configurationPeople = signal<PersonSummary[]>([]);
  readonly configuration = signal<BaseConfiguration>(emptyConfiguration());
  readonly configurationMessage = signal('');
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
      this.loadWorkspace();
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

  searchPeople(value: string): void {
    this.peopleLoading.set(true);
    this.http.get<PersonSummary[]>(`${environment.apiUrl}/people`, { params: { search: value, take: 100 } })
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: people => { this.people.set(people); this.peopleLoading.set(false); },
        error: () => this.peopleLoading.set(false)
      });
  }

  openPerson(id: number): void {
    this.http.get<PersonDetail>(`${environment.apiUrl}/people/${id}`)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe(person => this.selectedPerson.set(person));
  }

  closePerson(): void { this.selectedPerson.set(null); }

  saveConfiguration(): void {
    const baseId = this.auth.user()?.sisControl?.baseId;
    const value = this.configuration();
    if (baseId == null || !value.cityCode) {
      this.configurationMessage.set('Seleccione una ciudad de contratación.');
      return;
    }
    this.configurationMessage.set('Guardando...');
    this.http.put<void>(`${environment.apiUrl}/base-configuration/${baseId}`, value)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: () => this.configurationMessage.set('Configuración guardada correctamente.'),
        error: () => this.configurationMessage.set('No fue posible guardar la configuración.')
      });
  }

  private loadWorkspace(): void {
    if (this.selectedKey() === 'personal' && this.people().length === 0) this.searchPeople('');
    if (this.selectedKey() === 'configuracion') this.loadConfiguration();
  }

  private loadConfiguration(): void {
    const baseId = this.auth.user()?.sisControl?.baseId;
    if (baseId == null) {
      this.configurationMessage.set('El usuario no tiene una base SisControl asignada.');
      return;
    }
    this.http.get<BaseConfiguration>(`${environment.apiUrl}/base-configuration/${baseId}`)
      .pipe(takeUntilDestroyed(this.destroyRef)).subscribe(value => this.configuration.set(value));
    this.http.get<LookupItem[]>(`${environment.apiUrl}/base-configuration/cities`)
      .pipe(takeUntilDestroyed(this.destroyRef)).subscribe(value => this.cities.set(value));
    this.http.get<PersonSummary[]>(`${environment.apiUrl}/people`, { params: { take: 200 } })
      .pipe(takeUntilDestroyed(this.destroyRef)).subscribe(value => this.configurationPeople.set(value));
  }

  visibleReports(): typeof this.reports {
    const term = this.reportSearch().trim().toLocaleLowerCase();
    return term
      ? this.reports.filter(report =>
          `${report.group} ${report.name} ${report.description}`.toLocaleLowerCase().includes(term))
      : this.reports;
  }
}

interface PersonSummary {
  id: number; identification: string; fullName: string; mobile: string | null;
  email: string | null; birthDate: string | null;
}
interface PersonDetail extends PersonSummary {
  firstName: string | null; middleName: string | null; lastName: string | null;
  secondLastName: string | null; gender: string | null; address: string | null;
  phone: string | null; birthCity: string | null; residenceCity: string | null;
}
interface LookupItem { code: string; name: string; }
interface BaseConfiguration {
  baseId: number; contractCode: string | null; costCenterId: number | null; cityCode: string | null;
  qaqcCoordinatorId: number | null; hseCoordinatorId: number | null; doctorId: number | null;
  residentId: number | null; peopleManagerId: number | null; administratorId: number | null;
  warehouseManagerId: number | null; workwearDeliveryPlace: string | null;
}
function emptyConfiguration(): BaseConfiguration {
  return {
    baseId: 0, contractCode: null, costCenterId: null, cityCode: null, qaqcCoordinatorId: null,
    hseCoordinatorId: null, doctorId: null, residentId: null, peopleManagerId: null,
    administratorId: null, warehouseManagerId: null, workwearDeliveryPlace: null
  };
}
