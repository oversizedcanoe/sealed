import { Component } from '@angular/core';
import { KeyService } from '../../shared/key.service';
import { StorageService } from '../../shared/storage.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { KeyType } from '../../core/models';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.css'
})
export class LandingPageComponent {
  public existingCode: string = '';
  
  constructor(private codeService: KeyService, private storageService: StorageService, private router: Router) {
  }
  
  async generateCodes() {
    const keyPair = await this.codeService.createKeyPair();

    if (keyPair == undefined) {
      return;
    }

    this.storageService.createdKeyPair = keyPair;
    
    this.goToViewCodePage();
  }

  async useExistingCodes() {
    if(this.checkIsGuid(this.existingCode) == false){
      alert('Please input a valid code.');
      return;
    }

    const keyType = await this.codeService.getKeyType(this.existingCode);
    if (keyType == undefined){
      alert('Unknown code!');
      return;
    }

    // The reason we use the browser storage to temporarily store the codes when navigating to the 
    // ViewCode component is because we don't want sensitive data (private keys) stored in the browser
    // history, i.e. if we navigated to '/viewCode&key=ABCDEF...' the key would be easily accessible. 
    if (keyType == KeyType.Private) {
      this.storageService.privateKey = this.existingCode;
    }
    else if (keyType == KeyType.Public) {
      this.storageService.publicKey = this.existingCode;
    }

    this.goToViewCodePage();
  }

  checkIsGuid(value: string) {    
    var regex = /[a-f0-9]{8}(?:-[a-f0-9]{4}){3}-[a-f0-9]{12}/i;
    var match = regex.exec(value);
    return match != null;
  }

  goToViewCodePage(){
    this.router.navigate(['/viewcode']);
  }
}
