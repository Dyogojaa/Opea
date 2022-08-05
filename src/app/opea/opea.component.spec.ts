import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpeaComponent } from './opea.component';

describe('OpeaComponent', () => {
  let component: OpeaComponent;
  let fixture: ComponentFixture<OpeaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OpeaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OpeaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
