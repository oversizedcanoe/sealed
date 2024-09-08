import { Component } from '@angular/core';
import { CodeService } from '../../core/code.service';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.css'
})
export class LandingPageComponent {

  
  constructor(public codeService: CodeService) {
  }
  
  async generateCodes() {
    alert('generating');
    const privateCode = await this.codeService.generatePrivateCode();

    if (privateCode == undefined) {
      return;
    }


    alert(privateCode)


  }
  useExistingCodes() {
    alert('existing');

  }
}
