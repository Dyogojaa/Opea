import { TestBed } from '@angular/core/testing';

import { OpeaApiService } from './opea-api.service';

describe('OpeaApiService', () => {
  let service: OpeaApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OpeaApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
