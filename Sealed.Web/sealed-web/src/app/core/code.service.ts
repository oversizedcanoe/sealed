import { Injectable } from '@angular/core';
import { BackendService } from './backend.service';
import { ApiError } from './api-error';

@Injectable({
  providedIn: 'root'
})
export class CodeService {
  url: string = 'code';

  constructor(public backendService: BackendService) { }

  async generatePrivateCode(): Promise<string | undefined> {
    const result = await this.backendService.get<string>(this.url + '/getprivatecode');

    console.log(result);
    if (result instanceof ApiError) {
      console.error(result);
      return;
    }

    return result;
  }
}
