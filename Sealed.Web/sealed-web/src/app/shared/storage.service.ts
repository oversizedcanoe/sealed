import { Injectable } from '@angular/core';
import { Key, KeyPair } from '../core/models';

@Injectable({
    providedIn: 'root'
})

export class StorageService {

    get createdKeyPair(): KeyPair | null {
        const pair = sessionStorage.getItem('createdKeyPair');

        if (pair) {
            return JSON.parse(pair);
        }
        else {
            return null;
        }
    }

    set createdKeyPair(keyPair: KeyPair | null) {
        sessionStorage.setItem('createdKeyPair', JSON.stringify(keyPair))
    }


    get privateKey(): string | null {
        return sessionStorage.getItem('privateKey');
    }

    set privateKey(key: string | null) {
        if (key) {
            sessionStorage.setItem('privateKey', key)
        }
        else {
            sessionStorage.removeItem('privateKey')
        }
    }

    get publicKey(): string | null {
        return sessionStorage.getItem('publicKey');
    }

    set publicKey(key: string | null) {
        if (key) {
            sessionStorage.setItem('publicKey', key)
        }
        else {
            sessionStorage.removeItem('publicKey')
        }
    }
}