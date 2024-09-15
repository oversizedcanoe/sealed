import { Component } from '@angular/core';
import { KeyService } from '../../core/key.service';
import { StorageService } from '../../shared/storage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.css'
})
export class LandingPageComponent {

  
  constructor(private codeService: KeyService, private storageService: StorageService, private router: Router) {
  }
  
  async generateCodes() {
    alert('generating');
    const keyPair = await this.codeService.createKeyPair();

    if (keyPair == undefined) {
      return;
    }

    this.storageService.createdKeyPair = keyPair;

    this.router.navigate(['/viewcode']);
  }

  useExistingCodes() {
    alert('existing');

  }
}
