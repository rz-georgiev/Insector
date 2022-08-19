import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginFormComponent, ResetPasswordFormComponent, CreateAccountFormComponent, ChangePasswordFormComponent } from './shared/components';
import { AuthGuardService } from './shared/services';
import { SettingsProfileComponent } from './pages/settings-profile/settings-profile.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { DxDataGridModule, DxFormModule } from 'devextreme-angular';
import { SettingsTeamsComponent } from './pages/settings-teams/settings-teams.component';
import { SettingsProjectsComponent } from './pages/settings-projects/settings-projects.component';
import { SettingsUsersComponent } from './pages/settings-users/settings-users.component';
import { SettingsRolesComponent } from './pages/settings-roles/settings-roles.component';
import { SettingsTasksComponent } from './pages/settings-tasks/settings-tasks.component';
import { SettingsTassTypesComponent } from './pages/settings-task-types/settings-task-types.component';
import { SettingsProgressTypesComponent } from './pages/settings-progress-types/settings-progress-types.component';
import { WorkflowComponent } from './pages/workflow/workflow.component';

const routes: Routes = [
  {
    path: 'pages/workflow',
    component: WorkflowComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'pages/settings-progress-types',
    component: SettingsProgressTypesComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'pages/settings-task-types',
    component: SettingsTassTypesComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'pages/settings-tasks',
    component: SettingsTasksComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'pages/settings-roles',
    component: SettingsRolesComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'pages/settings-users',
    component: SettingsUsersComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'pages/settings-projects',
    component: SettingsProjectsComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'pages/settings-teams',
    component: SettingsTeamsComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'pages/dashboard',
    component: DashboardComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'profile',
    component: SettingsProfileComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'login-form',
    component: LoginFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'reset-password',
    component: ResetPasswordFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'create-account',
    component: CreateAccountFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'change-password/:recoveryCode',
    component: ChangePasswordFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: '**',
    redirectTo: 'home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true }), DxDataGridModule, DxFormModule],
  providers: [AuthGuardService],
  exports: [RouterModule],
  declarations: [
    DashboardComponent,
    SettingsProfileComponent,
    SettingsTeamsComponent,
    SettingsProjectsComponent,
    SettingsUsersComponent,
    SettingsRolesComponent,
    SettingsTasksComponent,
    SettingsTassTypesComponent,
    SettingsProgressTypesComponent,
    WorkflowComponent,
  ]
})
export class AppRoutingModule { }
