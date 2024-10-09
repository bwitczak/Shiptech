import { Component, OnInit, ViewChild, WritableSignal } from '@angular/core';
import { Ripple } from 'primeng/ripple';
import { StyleClassModule } from 'primeng/styleclass';
import { AvatarModule } from 'primeng/avatar';
import { HttpClient } from '@angular/common/http';
import { ShipWithNoRelationsDto } from '../../app/web-api-client';
import { ButtonModule } from 'primeng/button';
import { Drawer } from 'primeng/drawer';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [Ripple, StyleClassModule, AvatarModule, ButtonModule, Drawer],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
})
export class SidebarComponent implements OnInit {
  visible: boolean | WritableSignal<boolean> = false;
  @ViewChild('drawerRef') drawerRef!: Drawer;
  shipowners: ShipWithNoRelationsDto[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<ShipWithNoRelationsDto[]>('/api/Ships/GetAll').subscribe({
      next: (x) => {
        this.shipowners = x;
        console.log(x);
      },
    });
  }

  closeCallback(e: MouseEvent): void {
    this.drawerRef.close(e);
  }
}
