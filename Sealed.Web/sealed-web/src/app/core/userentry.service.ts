import { Injectable } from '@angular/core';
import { BackendService } from './backend.service';
import { ApiError } from './api-error';
import { KeyPair, UserEntry } from './models';

@Injectable({
  providedIn: 'root'
})

export class UserEntryService {
  url: string = 'userentry';

  constructor(public backendService: BackendService) { }

  async getUserEntries(privateKey: string): Promise<UserEntry[] | undefined> {
    const result = await this.backendService.get<UserEntry[]>(this.url + '/getuserentries/' + privateKey);

    console.log(result);
    if (result instanceof ApiError) {
      console.error(result);
      return;
    }

    return result;
  }
}
