import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-code',
  standalone: true,
  imports: [],
  templateUrl: './view-code.component.html',
  styleUrl: './view-code.component.css'
})
export class ViewCodeComponent implements OnInit {

  constructor(){

  }
  ngOnInit(): void {
    // Check query parameters
    // i.e.
    // site.com/viewcode&code=CODEGOESHERE
    // Backend would determine if this is a private or public key and return appropriately.
    // Then UI would query depending on if public or private
  }

}
