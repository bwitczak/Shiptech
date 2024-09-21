import { Component, OnInit, ViewChild, WritableSignal } from '@angular/core';
import { Sidebar, SidebarModule } from 'primeng/sidebar';
import { Button } from 'primeng/button';
import { Ripple } from 'primeng/ripple';
import { StyleClassModule } from 'primeng/styleclass';
import { AvatarModule } from 'primeng/avatar';
import { HttpClient } from '@angular/common/http';
import { ShipWithNoRelationsDto } from '../../app/web-api-client';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [SidebarModule, Button, Ripple, StyleClassModule, AvatarModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
})
export class SidebarComponent implements OnInit {
  sidebarVisible: boolean | WritableSignal<boolean> = false;
  @ViewChild('sidebarRef') sidebarRef!: Sidebar;
  shipowners: ShipWithNoRelationsDto[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<ShipWithNoRelationsDto[]>('/api/Ships/GetAll').subscribe({
      next: (x) => {
        this.shipowners = x;
      },
    });
  }

  closeCallback(e: MouseEvent): void {
    this.sidebarRef.close(e);
  }
}
