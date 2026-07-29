import { Component, EventEmitter, Input, Output, computed, signal } from '@angular/core';

export interface CityOption {
  code: string;
  name: string;
}

@Component({
  selector: 'app-city-picker',
  standalone: true,
  templateUrl: './city-picker.html',
  styleUrl: './city-picker.scss'
})
export class CityPicker {
  private cityOptions: CityOption[] = [];
  @Input() set cities(value: CityOption[]) {
    this.cityOptions = value;
    const selected = value.find(item => item.code === this.selectedCode());
    if (selected) this.query.set(this.label(selected));
  }
  get cities(): CityOption[] { return this.cityOptions; }
  @Input() placeholder = 'Código o nombre de la ciudad';
  @Input() required = false;
  @Input() set value(value: string | null) {
    this.selectedCode.set(value);
    const city = this.cities.find(item => item.code === value);
    if (city) this.query.set(this.label(city));
  }
  @Output() readonly valueChange = new EventEmitter<string | null>();
  @Output() readonly addRequested = new EventEmitter<void>();

  readonly query = signal('');
  readonly selectedCode = signal<string | null>(null);
  readonly open = signal(false);
  readonly filteredCities = computed(() => {
    const term = this.query().trim().toLocaleLowerCase();
    return (term
      ? this.cities.filter(city =>
          city.code.toLocaleLowerCase().includes(term) ||
          city.name.toLocaleLowerCase().includes(term))
      : this.cities).slice(0, 15);
  });

  search(value: string): void {
    this.query.set(value);
    this.selectedCode.set(null);
    this.valueChange.emit(null);
    this.open.set(true);
  }

  select(city: CityOption): void {
    this.selectedCode.set(city.code);
    this.query.set(this.label(city));
    this.valueChange.emit(city.code);
    this.open.set(false);
  }

  show(): void {
    this.open.set(true);
    if (this.selectedCode()) this.query.set('');
  }

  hide(): void {
    setTimeout(() => {
      this.open.set(false);
      const selected = this.cities.find(city => city.code === this.selectedCode());
      this.query.set(selected ? this.label(selected) : '');
    }, 150);
  }

  label(city: CityOption): string { return `${city.code} · ${city.name}`; }
}
