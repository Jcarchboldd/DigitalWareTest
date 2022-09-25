export interface Result<T> {
  Error: boolean;
  items: T[];
  ResponseMessage: string;
}
