import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-isos',
  standalone: true,
  imports: [],
  templateUrl: './isos.component.html',
  styleUrl: './isos.component.scss',
})
export class IsosComponent implements OnInit {
  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    const drawingId = this.route.snapshot.params['drawingId'];

    console.log(drawingId);
  }
}
