import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SettingsTassTypesComponent } from './settings-task-types.component';

describe('SettingsTassTypesComponent', () => {
  let component: SettingsTassTypesComponent;
  let fixture: ComponentFixture<SettingsTassTypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SettingsTassTypesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SettingsTassTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
