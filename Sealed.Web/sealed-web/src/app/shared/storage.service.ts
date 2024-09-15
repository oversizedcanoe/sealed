import { Injectable } from '@angular/core';
import { KeyPair } from '../core/models';

@Injectable({
    providedIn: 'root'
  })
  
export class StorageService{

    get createdKeyPair(): KeyPair | undefined {
        const pair = localStorage.getItem('createdKeyPair');

        if (pair) {
            return JSON.parse(pair);
        }
        else {
            return undefined;
        }
    }

    set createdKeyPair(keyPair: KeyPair | undefined){
        localStorage.setItem('createdKeyPair', JSON.stringify(keyPair))
    }
}