import { Component } from '@angular/core';
import { KeyService } from '../../core/key.service';
import { StorageService } from '../../shared/storage.service';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.css'
})
export class LandingPageComponent {

  
  constructor(public codeService: KeyService, public storageService: StorageService) {
  }
  
  async generateCodes() {
    alert('generating');
    const keyPair = await this.codeService.createKeyPair();

    if (keyPair == undefined) {
      return;
    }

    this.storageService.createdKeyPair = keyPair;

    // Navigate to view-code component and pass in a param like "viewcode?c=storage" so the component knows
    // to use the code just generated in storage.
    // Then ensure that the view code component clears storage and notifies the user they will lose the code 
    // if they don't copy it now. 
  }

  useExistingCodes() {
    alert('existing');

  }
}
