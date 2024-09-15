import { Injectable } from '@angular/core';
import { BackendService } from './backend.service';
import { ApiError } from './api-error';

export enum KeyType {
  Private = 1,
  Public = 2
}

export interface Key {
  code: string;
}

export interface KeyPair{
  privateKey: Key;
  publicKey: Key;
}

@Injectable({
  providedIn: 'root'
})

export class KeyService {
  url: string = 'key';

  constructor(public backendService: BackendService) { }

  async createKeyPair(): Promise<KeyPair | undefined> {
    const result = await this.backendService.post<KeyPair>(this.url + '/createkeypair');

    console.log(result);
    if (result instanceof ApiError) {
      console.error(result);
      return;
    }

    return result;
  }

  async getKeyType(key: string): Promise<KeyType | undefined> {
    const result = await this.backendService.get<KeyType>(this.url + '/getkeytype/' + key);

    console.log(result);
    if (result instanceof ApiError) {
      console.error(result);
      return;
    }

    return result;
  }

  async getPublicKey(privateKey: string): Promise<Key | undefined> {
    const result = await this.backendService.get<Key>(this.url + '/getpublickey/' + privateKey);
    
    console.log(result);
    if (result instanceof ApiError) {
      console.error(result);
      return;
    }

    return result;
  }
}
