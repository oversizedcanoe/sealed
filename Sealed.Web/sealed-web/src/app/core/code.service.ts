import { Injectable } from '@angular/core';
import { BackendService } from './backend.service';
import { CodePair } from './models';
import { lastValueFrom } from 'rxjs';
import { ApiError } from './api-error';

@Injectable({
  providedIn: 'root'
})
export class CodeService {
  url: string = 'code';

  constructor(public backendService: BackendService) { }

  async generateCodePair() {
    const result = await this.backendService.get<CodePair>(this.url + '/getpair');

    if (result instanceof ApiError) {
      alert('failed to generate pair')
      console.error(result);
      return;
    }

    alert('public: ' + result.publicKey)
    alert('private: ' + result.privateKey)
  }
}
