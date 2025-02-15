import { Component, OnInit, ViewChild } from '@angular/core';
import { Ripple } from 'primeng/ripple';
import { StyleClassModule } from 'primeng/styleclass';
import { AvatarModule } from 'primeng/avatar';
import { HttpClient } from '@angular/common/http';
import { ShipownerDto } from '../../app/web-api-client';
import { ButtonModule } from 'primeng/button';
import { Drawer } from 'primeng/drawer';
import { ChevronDown, LucideAngularModule, Menu, X } from 'lucide-angular';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [
    Ripple,
    StyleClassModule,
    AvatarModule,
    ButtonModule,
    Drawer,
    LucideAngularModule,
  ],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
})
export class SidebarComponent implements OnInit {
  visible: boolean;
  @ViewChild('drawerRef') drawerRef!: Drawer;
  shipowners: ShipownerDto[] = [];
  readonly Menu = Menu;
  readonly X = X;
  readonly ChevronDown = ChevronDown;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<ShipownerDto[]>('/api/Shipowners/GetAll').subscribe({
      next: (x) => {
        this.shipowners = x;
      },
    });
  }

  closeCallback(e: MouseEvent): void {
    this.drawerRef.close(e);
  }
}
