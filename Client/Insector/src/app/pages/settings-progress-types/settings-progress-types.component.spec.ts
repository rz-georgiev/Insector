import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SettingsProgressTypesComponent } from './settings-progress-types.component';

describe('SettingsProgressTypesComponent', () => {
  let component: SettingsProgressTypesComponent;
  let fixture: ComponentFixture<SettingsProgressTypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SettingsProgressTypesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SettingsProgressTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
