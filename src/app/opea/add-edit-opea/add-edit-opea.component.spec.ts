import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditOpeaComponent } from './add-edit-opea.component';

describe('AddEditOpeaComponent', () => {
  let component: AddEditOpeaComponent;
  let fixture: ComponentFixture<AddEditOpeaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditOpeaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditOpeaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
