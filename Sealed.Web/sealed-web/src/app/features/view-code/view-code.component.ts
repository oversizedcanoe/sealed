import { Component, OnInit } from '@angular/core';
import { StorageService } from '../../shared/storage.service';
import { KeyPair, UserEntry } from '../../core/models';
import { UserEntryService } from '../../core/user-entry.service';
import { KeyService } from '../../core/key.service';

@Component({
  selector: 'app-view-code',
  standalone: true,
  imports: [],
  templateUrl: './view-code.component.html',
  styleUrl: './view-code.component.css'
})
export class ViewCodeComponent implements OnInit {

  public privateKey: string = '';
  public publicKey: string = ''
  public userEntries: UserEntry[] = [];
  public showForm: boolean = false;

  constructor(private storage: StorageService, private userEntryService: UserEntryService, private keyService: KeyService) {

  }

  async ngOnInit(): Promise<void> {
    // Check if the user has a key in the URL.
    // Users can link to the public code input form with "/viewcode&c=ABCDEF"


    await this.setupPageFromStorage();
  }

  async setupPageFromStorage(): Promise<void> {
    // Check if there are created codes in storage.
    // They will be cleared from storage below if they are not null as the user must copy them immediately
    // or lose them forever.
    const keyPair: KeyPair | null = this.storage.createdKeyPair;
    const storagePrivateKey: string | null = this.storage.privateKey;
    const storagePublicKey: string | null = this.storage.publicKey;

    console.log('keyPair', keyPair);
    console.log('storagePrivateKey', storagePrivateKey);
    console.log('storagePublicKey', storagePublicKey);

    if (keyPair != null) {
      // User came from the home page.
      this.storage.createdKeyPair = null;
      this.showPrivateKeyPage(keyPair.privateKey.code, keyPair.publicKey.code);
    }
    else if (storagePrivateKey != null) {
      // User entered their existing code and it was a private key.
      this.storage.privateKey = null;
      const publicKey = await this.keyService.getPublicKey(this.privateKey);

      if (publicKey) {
        this.showPrivateKeyPage(storagePrivateKey, publicKey.code);
      }
    }
    else if (storagePublicKey != null) {
      // User entered their existing code and it was a public key.
      this.storage.publicKey = null;
      this.showPublicKeyPage(storagePublicKey);
    }

  }

  showPrivateKeyPage(privateKey: string, publicKey: string) {
    this.privateKey = privateKey;
    this.publicKey = publicKey;

    this.showUserEntries();
  }

  showPublicKeyPage(publicKey: string) {
    this.publicKey = publicKey;
    this.showForm = true;
  }

  async showUserEntries(): Promise<void> {
    const result = await this.userEntryService.getUserEntries(this.privateKey);

    if (result != undefined) {
      this.userEntries = result;
    }
  }

  submitUserEntry(){
    
  }
}
