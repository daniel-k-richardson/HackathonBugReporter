export interface Bug {
  ID: number;
  GlobalIdentity: string;
  Status: BugStatus;
}

export enum BugStatus {
  Todo = 0,
  InProgress = 10,
  Completed = 20
}