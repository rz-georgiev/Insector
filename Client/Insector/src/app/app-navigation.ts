export const navigation = [
  {
    text: 'Dashboard',
    path: '/pages/dashboard',
    icon: 'chart'
  },
  {
    text: 'Workflow',
    path: '/pages/workflow',
    icon: 'event'
  },
  {
    text: 'Settings',
    icon: 'preferences',
    items: [
      {
        text: 'Users',
        path: '/pages/settings-users'
      },
      {
        text: 'Roles',
        path: '/pages/settings-roles'
      },
      {
        text: 'Teams',
        path: '/pages/settings-teams'
      },
      {
        text: 'Projects',
        path: '/pages/settings-projects'
      },
      {
        text: 'Tasks',
        path: '/pages/settings-tasks'
      },
      {
        text: 'Task types',
        path: '/pages/settings-task-types'
      },
      {
        text: 'Progress types',
        path: '/pages/settings-progress-types'
      },
    ]
  }
];
