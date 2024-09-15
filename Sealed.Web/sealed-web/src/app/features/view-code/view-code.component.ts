import { Component, OnInit } from '@angular/core';
import { StorageService } from '../../shared/storage.service';
import { KeyPair } from '../../core/key.service';

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

  constructor(private storage: StorageService){

  }

  ngOnInit(): void {
    // Check if there are created codes in storage.
    const keyPair: KeyPair | undefined = this.storage.createdKeyPair;

    if (keyPair != undefined) {
      this.privateKey = keyPair.privateKey.code;
      this.publicKey = keyPair.publicKey.code;

      // User must copy the codes now as we don't want them refreshing the page and seeing them again.
      this.storage.createdKeyPair = undefined;

      this.showUserEntries();
      return;
    }

    // Check route/query parameters
    // get param from url
    // if is private key
    //    query for public key
    //    set this.private/this.public
    //    this.showUserEntries();
    // if is public key
    //    show form to submit
    // else show error/invalid key
  }

  showUserEntries(): void {

  }

}
