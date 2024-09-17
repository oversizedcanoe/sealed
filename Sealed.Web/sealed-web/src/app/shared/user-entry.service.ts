import { Injectable } from '@angular/core';
import { BackendService } from '../core/backend.service';
import { ApiError } from '../core/api-error';
import { UserEntry } from '../core/models';

@Injectable({
  providedIn: 'root'
})

export class UserEntryService {
  url: string = 'userentry';

  constructor(public backendService: BackendService) { }

  async getUserEntries(privateKey: string): Promise<UserEntry[] | undefined> {
    const result = await this.backendService.get<UserEntry[]>(this.url + '/getuserentries/' + privateKey);

    if (result instanceof ApiError) {
      return;
    }

    return result;
  }

  async addUserEntry(publicKey: string, entryText: string): Promise<UserEntry | undefined> {
    var body = {text: entryText};
  
    const result = await this.backendService.post<UserEntry>(this.url + '/adduserentry/' + publicKey,  body);

    if (result instanceof ApiError) {
      return;
    }

    return result;
  }
}
