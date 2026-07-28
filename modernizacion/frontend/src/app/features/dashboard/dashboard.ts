import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { SystemModule } from '../../core/auth.models';
import { AuthService } from '../../core/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss'
})
export class Dashboard implements OnInit {
  private readonly http = inject(HttpClient);
  readonly auth = inject(AuthService);
  readonly modules = signal<SystemModule[]>([]);

  ngOnInit(): void {
    this.http.get<SystemModule[]>(`${environment.apiUrl}/system/modules`)
      .subscribe({ next: modules => this.modules.set(modules) });
  }
}
