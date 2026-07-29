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
  readonly peoplePage = signal(1);
  readonly peopleTotal = signal(0);
  readonly peopleSearch = signal('');
  readonly personRegistrationOpen = signal(false);
  readonly personRegistrationStep = signal(1);
  readonly personRegistrationMessage = signal('');
  readonly newPerson = signal<NewPersonForm>(emptyPersonForm());
  readonly personnelSection = signal('personas');
  readonly personnelAction = signal('cargar');
  readonly contact = signal<ContactInfo | null>(null);
  readonly contactMessage = signal('');
  readonly processRecords = signal<Record<string, unknown>[]>([]);
  readonly processColumns = signal<string[]>([]);
  readonly processLoading = signal(false);
  readonly processError = signal('');
  readonly processPage = signal(1);
  readonly processTotal = signal(0);
  readonly processCategory = signal('');
  readonly pageSize = 20;
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
  readonly personnelGroups: PersonnelGroup[] = [
    { key: 'personas', name: 'Persona', actions: [
      ['cargar', 'Cargar personas', 560], ['ver', 'Ver persona', 209],
      ['registrar', 'Registrar persona', 39], ['registrar-basico', 'Registrar persona básico', 39],
      ['editar', 'Editar persona', 40], ['editar-basico', 'Editar persona básico', 40],
      ['desactivar', 'Desactivar', 41], ['buscar', 'Buscar persona', 555],
      ['formatos', 'Imprimir formatos', 45], ['contrato', 'Registrar contrato', 42],
      ['subir-hv', 'Subir validación hoja de vida', 883], ['ver-hv', 'Ver validación hoja de vida', 884]
    ]},
    { key: 'estado', name: 'Verificar estado', actions: [
      ['registrar-estado', 'Registrar estado', 867], ['consultar-estado', 'Consultar estado', 868],
      ['resumen', 'Ver resumen', 869], ['historial', 'Historial de consultas', 870],
      ['agregar-seguridad', 'Agregar persona', 885]
    ]},
    { key: 'examenes', name: 'Exámenes médicos', actions: [
      ['listar-examenes', 'Cargar listado', 704], ['enviar-examenes', 'Enviar a exámenes', 703],
      ['habilitar-examen', 'Habilitar edición', 881], ['editar-examen', 'Editar examen', 882],
      ['concepto', 'Agregar concepto', 707], ['ver-examen', 'Ver examen', 706],
      ['buscar-examen', 'Buscar', 705], ['imprimir-examen', 'Reimpresión de exámenes', 702],
      ['vacunas', 'Agregar vacunas', 954]
    ]},
    { key: 'covid', name: 'COVID-19', actions: [
      ['listar-encuestas', 'Cargar encuestas', 774], ['crear-encuesta', 'Crear encuesta', 775],
      ['editar-encuesta', 'Editar encuesta', 776], ['buscar-encuesta', 'Buscar encuesta', 777],
      ['cancelar-encuesta', 'Cancelar encuesta', 778], ['imprimir-encuesta', 'Imprimir encuesta', 779],
      ['autorizar-ingreso', 'Autorizar ingreso', 781], ['temperatura', 'Registrar temperatura', 781]
    ]},
    { key: 'calificacion', name: 'Programa calificación', actions: [
      ['calificaciones', 'Cargar calificaciones', 718], ['agregar-calificacion', 'Agregar calificación', 719],
      ['gestionar-calificacion', 'Gestionar calificaciones', 720], ['capacitaciones', 'Programar capacitaciones', 772],
      ['carnet', 'Imprimir carnet', 721]
    ]},
    { key: 'evaluacion', name: 'Evaluación desempeño', actions: [
      ['listar-evaluacion', 'Listar', 859], ['crear-evaluacion', 'Crear', 860],
      ['ver-evaluacion', 'Ver', 861], ['editar-evaluacion', 'Editar', 862],
      ['buscar-evaluacion', 'Buscar', 863], ['correo-evaluacion', 'Enviar correos', 864],
      ['correo-bloque', 'Enviar correos en bloque', 865]
    ]}
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

  searchPeople(value: string, page = 1): void {
    this.peopleSearch.set(value);
    this.peoplePage.set(page);
    this.peopleLoading.set(true);
    this.http.get<PagedResult<PersonSummary>>(`${environment.apiUrl}/people`,
      { params: { search: value, page, pageSize: this.pageSize } })
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: result => {
          this.people.set(result.items);
          this.peopleTotal.set(result.total);
          this.peoplePage.set(result.page);
          this.peopleLoading.set(false);
        },
        error: () => this.peopleLoading.set(false)
      });
  }

  changePeoplePage(page: number): void {
    if (page >= 1 && page <= this.totalPages(this.peopleTotal())) this.searchPeople(this.peopleSearch(), page);
  }

  changeProcessPage(page: number): void {
    if (page >= 1 && page <= this.totalPages(this.processTotal())) this.loadProcess(this.processCategory(), page);
  }

  totalPages(total: number): number { return Math.max(1, Math.ceil(total / this.pageSize)); }
  pageEnd(page: number, total: number): number { return Math.min(page * this.pageSize, total); }

  openPerson(id: number): void {
    this.http.get<PersonDetail>(`${environment.apiUrl}/people/${id}`)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe(person => {
        this.selectedPerson.set(person);
        this.http.get<ContactInfo>(`${environment.apiUrl}/class-base/contacts/${id}`)
          .pipe(takeUntilDestroyed(this.destroyRef))
          .subscribe(contact => this.contact.set(contact));
      });
  }

  closePerson(): void { this.selectedPerson.set(null); this.contact.set(null); }

  openPersonRegistration(): void {
    this.newPerson.set(emptyPersonForm());
    this.personRegistrationStep.set(1);
    this.personRegistrationMessage.set('');
    this.personRegistrationOpen.set(true);
    if (this.cities().length === 0) {
      this.http.get<LookupItem[]>(`${environment.apiUrl}/base-configuration/cities`)
        .pipe(takeUntilDestroyed(this.destroyRef))
        .subscribe(value => this.cities.set(value));
    }
  }

  closePersonRegistration(): void { this.personRegistrationOpen.set(false); }

  nextPersonStep(): void {
    const person = this.newPerson();
    if (!person.identification.trim() || !person.firstName.trim() || !person.lastName.trim()) {
      this.personRegistrationMessage.set('Complete identificación, primer nombre y primer apellido.');
      return;
    }
    this.personRegistrationMessage.set('');
    this.personRegistrationStep.set(2);
  }

  previousPersonStep(): void {
    this.personRegistrationMessage.set('');
    this.personRegistrationStep.set(1);
  }

  preparePersonRegistration(): void {
    const person = this.newPerson();
    if (!person.birthCityCode || !person.residenceCityCode) {
      this.personRegistrationMessage.set('Seleccione ciudad de nacimiento y ciudad de residencia.');
      return;
    }
    if (person.email && !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(person.email)) {
      this.personRegistrationMessage.set('El correo electrónico no tiene un formato válido.');
      return;
    }
    this.personRegistrationMessage.set('Formulario validado. El registro está listo para enviarse al procedimiento de Personas.');
  }

  selectPersonnelAction(group: string, action: string): void {
    this.personnelSection.set(group);
    this.personnelAction.set(action);
    if (action === 'cargar' || action === 'buscar') this.searchPeople('');
    if (action === 'registrar' || action === 'registrar-basico') this.openPersonRegistration();
    const category: Record<string, string> = {
      examenes: 'medical-exams',
      covid: 'covid-surveys',
      calificacion: 'qualifications',
      evaluacion: 'performance-evaluations'
    };
    if (category[group]) this.loadProcess(category[group], 1);
  }

  displayValue(value: unknown): string {
    if (value === null || value === undefined || value === '') return '—';
    if (typeof value === 'boolean') return value ? 'Sí' : 'No';
    const text = String(value);
    return /^\d{4}-\d{2}-\d{2}T/.test(text) ? text.slice(0, 10) : text;
  }

  personnelGroupName(): string {
    return this.personnelGroups.find(group => group.key === this.personnelSection())?.name ?? 'Personal';
  }

  updateContact(): void {
    const value = this.contact();
    if (!value) return;
    this.contactMessage.set('Guardando...');
    this.http.put<void>(`${environment.apiUrl}/class-base/contacts/${value.personId}`, value)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: () => this.contactMessage.set('Contacto actualizado correctamente.'),
        error: error => this.contactMessage.set(error.error?.error ?? 'No fue posible actualizar el contacto.')
      });
  }

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

  private loadProcess(category: string, page = 1): void {
    if (!category) return;
    this.processCategory.set(category);
    this.processPage.set(page);
    this.processLoading.set(true);
    this.processError.set('');
    const baseId = this.auth.user()?.sisControl?.baseId ?? 0;
    this.http.get<PagedResult<Record<string, unknown>>>(`${environment.apiUrl}/personnel/processes/${category}`,
      { params: { baseId, page, pageSize: this.pageSize } })
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: result => {
          this.processRecords.set(result.items);
          this.processTotal.set(result.total);
          this.processPage.set(result.page);
          this.processColumns.set(result.items.length ? Object.keys(result.items[0]).slice(0, 8) : []);
          this.processLoading.set(false);
        },
        error: () => {
          this.processError.set('No fue posible cargar la información de esta categoría.');
          this.processLoading.set(false);
        }
      });
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
    this.http.get<PagedResult<PersonSummary>>(`${environment.apiUrl}/people`, { params: { page: 1, pageSize: 200 } })
      .pipe(takeUntilDestroyed(this.destroyRef)).subscribe(value => this.configurationPeople.set(value.items));
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
interface ContactInfo {
  personId: number; fullName: string; personalEmail: string; personalMobile: string;
  corporateEmail: string; corporateMobile: string;
}
interface PersonnelGroup { key: string; name: string; actions: [string, string, number][]; }
interface PagedResult<T> { items: T[]; total: number; page: number; pageSize: number; }
interface NewPersonForm {
  identificationType: string; identification: string; issueDate: string; issueCityCode: string | null;
  firstName: string; middleName: string; lastName: string; secondLastName: string;
  birthDate: string; birthCityCode: string | null; gender: string;
  residenceCityCode: string | null; address: string; mobile: string; phone: string;
  email: string; bloodType: string; employee: boolean; client: boolean; contractor: boolean;
}
function emptyPersonForm(): NewPersonForm {
  return {
    identificationType: 'CC', identification: '', issueDate: '', issueCityCode: null,
    firstName: '', middleName: '', lastName: '', secondLastName: '', birthDate: '',
    birthCityCode: null, gender: '', residenceCityCode: null, address: '', mobile: '',
    phone: '', email: '', bloodType: 'SIN', employee: false, client: false, contractor: false
  };
}
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
