import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowOpeaComponent } from './show-opea.component';

describe('ShowOpeaComponent', () => {
  let component: ShowOpeaComponent;
  let fixture: ComponentFixture<ShowOpeaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowOpeaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowOpeaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
