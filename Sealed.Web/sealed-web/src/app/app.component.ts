import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BackendService } from './core/backend.service';
import { CodeService } from './core/code.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'sealed-web';

  constructor(public codeService: CodeService) {
  }
  async generateCodes() {
    alert('generating');
    const codePair = await this.codeService.generateCodePair();

    if (codePair == undefined) {
      return;
    }


  }
  useExistingCodes() {
    alert('existing');

  }
}
