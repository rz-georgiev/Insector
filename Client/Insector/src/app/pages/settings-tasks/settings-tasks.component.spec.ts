import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SettingsTasksComponent } from './settings-tasks.component';

describe('SettingsTasksComponent', () => {
  let component: SettingsTasksComponent;
  let fixture: ComponentFixture<SettingsTasksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SettingsTasksComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SettingsTasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
