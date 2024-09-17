import { Component, OnInit } from '@angular/core';
import { StorageService } from '../../shared/storage.service';
import { KeyPair, UserEntry } from '../../core/models';
import { UserEntryService } from '../../shared/user-entry.service';
import { KeyService } from '../../shared/key.service';
import { FormsModule } from '@angular/forms';
import { Clipboard, ClipboardModule } from '@angular/cdk/clipboard'
import { showToast } from '../../shared/document-utility';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-code',
  standalone: true,
  imports: [FormsModule, ClipboardModule],
  templateUrl: './view-code.component.html',
  styleUrl: './view-code.component.css'
})
export class ViewCodeComponent implements OnInit {
  public privateKey: string = '';
  public publicKey: string = '';
  public userEntry: string = '';
  public userEntries: UserEntry[] = [];

  public showPrivateKeyForm: boolean = false;
  public showForm: boolean = false;

  constructor(private storage: StorageService, 
    private userEntryService: UserEntryService, 
    private keyService: KeyService, 
    private clipboard: Clipboard,
    private route: ActivatedRoute) {
  }

  async ngOnInit(): Promise<void> {
    // Check if the user has a key in the URL.
    // Users can link to the public code input form with "/viewcode&c=ABCDEF"
    const queryParamCode: string | null = this.route.snapshot.queryParamMap.get('c');

    if (queryParamCode){
      this.showPublicKeyPage(queryParamCode);
      return;
    }

    await this.setupPageFromStorage();
  }

  anyKeySelected(){
    return this.privateKey != '' || this.publicKey != '';
  }

  async setupPageFromStorage(): Promise<void> {
    // Check if there are created codes in storage.
    // They will be cleared from storage below if they are not null as the user must copy them immediately
    // or lose them forever.
    const keyPair: KeyPair | null = this.storage.createdKeyPair;
    const storagePrivateKey: string | null = this.storage.privateKey;
    const storagePublicKey: string | null = this.storage.publicKey;

    if (keyPair != null) {
      // User came from the home page.
      this.storage.createdKeyPair = null;
      this.showPrivateKeyPage(keyPair.privateKey.code, keyPair.publicKey.code);
    }
    else if (storagePrivateKey != null) {
      // User entered their existing code and it was a private key.
      this.storage.privateKey = null;
      console.log(this.privateKey)
      const publicKey = await this.keyService.getPublicKey(storagePrivateKey);

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
    this.showPrivateKeyForm = true;
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

  async submitUserEntry(){
    const result = await this.userEntryService.addUserEntry(this.publicKey, this.userEntry);

    if (result){
      this.userEntries.push(result);
    }

    this.userEntry = '';
  }

  copyPublicLink(){
    this.clipboard.copy(`localhost:4200/viewcode?c=${this.publicKey}`);
    showToast('Link Copied!');
  }

  copyPublicCode(){
    this.clipboard.copy(this.publicKey);
    showToast('Code Copied!');
  }

}
