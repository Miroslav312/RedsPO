# Business

## Contents

- [EventBusiness](#T-Business-EventBusiness 'Business.EventBusiness')
  - [AddEvent(userEvent)](#M-Business-EventBusiness-AddEvent-Event- 'Business.EventBusiness.AddEvent(Event)')
  - [FetchEventById(id,user)](#M-Business-EventBusiness-FetchEventById-System-Int32,User- 'Business.EventBusiness.FetchEventById(System.Int32,User)')
  - [ListAllEvents(user)](#M-Business-EventBusiness-ListAllEvents-User- 'Business.EventBusiness.ListAllEvents(User)')
  - [ListAllEventsByDate(date,user)](#M-Business-EventBusiness-ListAllEventsByDate-System-DateTime,User- 'Business.EventBusiness.ListAllEventsByDate(System.DateTime,User)')
  - [ModifyEvent(userEvent,user)](#M-Business-EventBusiness-ModifyEvent-Event,User- 'Business.EventBusiness.ModifyEvent(Event,User)')
  - [RemoveAllEvents(user)](#M-Business-EventBusiness-RemoveAllEvents-User- 'Business.EventBusiness.RemoveAllEvents(User)')
  - [RemoveEvent(id,user)](#M-Business-EventBusiness-RemoveEvent-System-Int32,User- 'Business.EventBusiness.RemoveEvent(System.Int32,User)')
- [ReminderBusiness](#T-Business-ReminderBusiness 'Business.ReminderBusiness')
  - [AddReminder(userReminder)](#M-Business-ReminderBusiness-AddReminder-Reminder- 'Business.ReminderBusiness.AddReminder(Reminder)')
  - [FetchReminderById(id,user)](#M-Business-ReminderBusiness-FetchReminderById-System-Int32,User- 'Business.ReminderBusiness.FetchReminderById(System.Int32,User)')
  - [ListAllReminders(user)](#M-Business-ReminderBusiness-ListAllReminders-User- 'Business.ReminderBusiness.ListAllReminders(User)')
  - [ListAllRemindersByDate(date,user)](#M-Business-ReminderBusiness-ListAllRemindersByDate-System-DateTime,User- 'Business.ReminderBusiness.ListAllRemindersByDate(System.DateTime,User)')
  - [ModifyReminder(userReminder,user)](#M-Business-ReminderBusiness-ModifyReminder-Reminder,User- 'Business.ReminderBusiness.ModifyReminder(Reminder,User)')
  - [RemoveAllReminders(user)](#M-Business-ReminderBusiness-RemoveAllReminders-User- 'Business.ReminderBusiness.RemoveAllReminders(User)')
  - [RemoveReminder(id,user)](#M-Business-ReminderBusiness-RemoveReminder-System-Int32,User- 'Business.ReminderBusiness.RemoveReminder(System.Int32,User)')
- [TaskBusiness](#T-Business-TaskBusiness 'Business.TaskBusiness')
  - [AddTask(userTask)](#M-Business-TaskBusiness-AddTask-Task- 'Business.TaskBusiness.AddTask(Task)')
  - [CompleteTask(id,user)](#M-Business-TaskBusiness-CompleteTask-System-Int32,User- 'Business.TaskBusiness.CompleteTask(System.Int32,User)')
  - [FetchTaskById(id,user)](#M-Business-TaskBusiness-FetchTaskById-System-Int32,User- 'Business.TaskBusiness.FetchTaskById(System.Int32,User)')
  - [ListAllCompletedTasks(user)](#M-Business-TaskBusiness-ListAllCompletedTasks-User- 'Business.TaskBusiness.ListAllCompletedTasks(User)')
  - [ListAllTasks(user)](#M-Business-TaskBusiness-ListAllTasks-User- 'Business.TaskBusiness.ListAllTasks(User)')
  - [ListAllTasksByDate(date,user)](#M-Business-TaskBusiness-ListAllTasksByDate-System-DateTime,User- 'Business.TaskBusiness.ListAllTasksByDate(System.DateTime,User)')
  - [ListAllUncompletedTasks(user)](#M-Business-TaskBusiness-ListAllUncompletedTasks-User- 'Business.TaskBusiness.ListAllUncompletedTasks(User)')
  - [ModifyTask(userTask,user)](#M-Business-TaskBusiness-ModifyTask-Task,User- 'Business.TaskBusiness.ModifyTask(Task,User)')
  - [RemoveAllCompletedTasks(user)](#M-Business-TaskBusiness-RemoveAllCompletedTasks-User- 'Business.TaskBusiness.RemoveAllCompletedTasks(User)')
  - [RemoveAllTasks(user)](#M-Business-TaskBusiness-RemoveAllTasks-User- 'Business.TaskBusiness.RemoveAllTasks(User)')
  - [RemoveTask(id,user)](#M-Business-TaskBusiness-RemoveTask-System-Int32,User- 'Business.TaskBusiness.RemoveTask(System.Int32,User)')
- [UserBusiness](#T-Business-UserBusiness 'Business.UserBusiness')
  - [FetchAllUsers()](#M-Business-UserBusiness-FetchAllUsers 'Business.UserBusiness.FetchAllUsers')
  - [FetchUser(userName,passwordHash)](#M-Business-UserBusiness-FetchUser-System-String,System-String- 'Business.UserBusiness.FetchUser(System.String,System.String)')
  - [GetStringFromHash(hash)](#M-Business-UserBusiness-GetStringFromHash-System-Byte[]- 'Business.UserBusiness.GetStringFromHash(System.Byte[])')
  - [HashPassword(password)](#M-Business-UserBusiness-HashPassword-System-String- 'Business.UserBusiness.HashPassword(System.String)')
  - [IsExisting(user)](#M-Business-UserBusiness-IsExisting-User- 'Business.UserBusiness.IsExisting(User)')
  - [Register(user)](#M-Business-UserBusiness-Register-User- 'Business.UserBusiness.Register(User)')

## EventBusiness `type`

##### Namespace

Business

### AddEvent(userEvent) `Method`

##### Summary

Adds the event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userEvent | [Event](#T-Event 'Event') | The user event. |

### FetchEventById(id,user) `Method`

##### Summary

Fetches the event by identifier.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The identifier. |
| user | [User](#T-User 'User') | The user. |

### ListAllEvents(user) `Method`

##### Summary

Lists all events.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [User](#T-User 'User') | The user. |

### ListAllEventsByDate(date,user) `Method`

##### Summary

Lists all events by date.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| date | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') | The date. |
| user | [User](#T-User 'User') | The user. |

### ModifyEvent(userEvent,user) `Method`

##### Summary

Modifies the event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userEvent | [Event](#T-Event 'Event') | The user event. |
| user | [User](#T-User 'User') | The user. |

### RemoveAllEvents(user) `Method`

##### Summary

Removes all events.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [User](#T-User 'User') | The user. |

### RemoveEvent(id,user) `Method`

##### Summary

Removes the event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The identifier. |
| user | [User](#T-User 'User') | The user. |

## ReminderBusiness `type`

##### Namespace

Business

### AddReminder(userReminder) `Method`

##### Summary

Adds the reminder.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userReminder | [Reminder](#T-Reminder 'Reminder') | The user reminder. |

### FetchReminderById(id,user) `Method`

##### Summary

Fetches the reminder by identifier.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The identifier. |
| user | [User](#T-User 'User') | The user. |

### ListAllReminders(user) `Method`

##### Summary

Lists all reminders.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [User](#T-User 'User') | The user. |

### ListAllRemindersByDate(date,user) `Method`

##### Summary

Lists all reminders by date.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| date | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') | The date. |
| user | [User](#T-User 'User') | The user. |

### ModifyReminder(userReminder,user) `Method`

##### Summary

Modifies the reminder.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userReminder | [Reminder](#T-Reminder 'Reminder') | The user reminder. |
| user | [User](#T-User 'User') | The user. |

### RemoveAllReminders(user) `Method`

##### Summary

Removes all reminders.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [User](#T-User 'User') | The user. |

### RemoveReminder(id,user) `Method`

##### Summary

Removes the reminder.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The identifier. |
| user | [User](#T-User 'User') | The user. |

## TaskBusiness `type`

##### Namespace

Business

### AddTask(userTask) `Method`

##### Summary

Adds the task.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userTask | [Task](#T-Task 'Task') | The user task. |

### CompleteTask(id,user) `Method`

##### Summary

Completes the Task.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The identifier. |
| user | [User](#T-User 'User') | The user. |

### FetchTaskById(id,user) `Method`

##### Summary

Fetches the Task by identifier.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The identifier. |
| user | [User](#T-User 'User') | The user. |

### ListAllCompletedTasks(user) `Method`

##### Summary

Lists all completed Tasks.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [User](#T-User 'User') | The user. |

### ListAllTasks(user) `Method`

##### Summary

Lists all Tasks.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [User](#T-User 'User') | The user. |

### ListAllTasksByDate(date,user) `Method`

##### Summary

Lists all Tasks by date.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| date | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') | The date. |
| user | [User](#T-User 'User') | The user. |

### ListAllUncompletedTasks(user) `Method`

##### Summary

Lists all uncompleted Tasks.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [User](#T-User 'User') | The user. |

### ModifyTask(userTask,user) `Method`

##### Summary

Modifies the task.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userTask | [Task](#T-Task 'Task') | The user task. |
| user | [User](#T-User 'User') | The user. |

### RemoveAllCompletedTasks(user) `Method`

##### Summary

Removes all completed Tasks.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [User](#T-User 'User') | The user. |

### RemoveAllTasks(user) `Method`

##### Summary

Removes all Tasks.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [User](#T-User 'User') | The user. |

### RemoveTask(id,user) `Method`

##### Summary

Removes the Task.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The identifier. |
| user | [User](#T-User 'User') | The user. |

## UserBusiness `type`

##### Namespace

Business

### FetchAllUsers() `Method`

##### Summary

Fetches all users.

##### Parameters

This Method has no parameters.

### FetchUser(userName,passwordHash) `Method`

##### Summary

Fetches the user.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the user. |
| passwordHash | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The password hash. |

### GetStringFromHash(hash) `Method`

##### Summary

Gets string from hash.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| hash | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | The hash. |

### HashPassword(password) `Method`

##### Summary

Hashes the password with SHA256 Hash.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The password. |

### IsExisting(user) `Method`

##### Summary

Determines whether the specified user is existing.

##### Returns

`true` if the specified user is existing; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [User](#T-User 'User') | The user. |

### Register(user) `Method`

##### Summary

Registers the specified user.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [User](#T-User 'User') | The user. |
