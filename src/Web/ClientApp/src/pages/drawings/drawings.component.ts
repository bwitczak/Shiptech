import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-drawings',
  standalone: true,
  imports: [],
  templateUrl: './drawings.component.html',
  styleUrl: './drawings.component.scss',
})
export class DrawingsComponent implements OnInit {
  constructor(private route: ActivatedRoute) {}
  ngOnInit() {
    const shipId = this.route.snapshot.params['shipId'];

    console.log(shipId);
  }
}
