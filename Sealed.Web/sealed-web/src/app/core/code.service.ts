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

  async generateCodePair(): Promise<CodePair | undefined> {
    const result = await this.backendService.get<CodePair>(this.url + '/getpair');

    if (result instanceof ApiError) {
      alert('Failed to generate pair!')
      console.error(result);
      return;
    }

    console.log(result);

    return result;
  }
}
