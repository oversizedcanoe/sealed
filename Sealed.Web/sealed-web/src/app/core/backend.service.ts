import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';
import { ApiError } from './api-error';

@Injectable({
  providedIn: 'root'
})
export class BackendService {
  baseUrl: string = 'https://localhost:7084/api/'
  constructor(public httpClient: HttpClient) {
  }

  async get<T>(url: string, res: 'text' | 'json' | undefined = 'json'): Promise<T | ApiError> {
    const result$ = this.httpClient.get(this.baseUrl + url, { observe: 'response', responseType: res});
    const result = await lastValueFrom(result$);

    console.log(result)
    if (result.ok) {
      return result.body as T;
    }
    else {
      return new ApiError(result.statusText, result.status)
    }
  }

  post(url: string, body: {}): Observable<object> | ApiError {
    return this.httpClient.post(url, body);
  }
}

