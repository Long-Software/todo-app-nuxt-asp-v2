export interface ApiResponse<T>  {
  Data: T;
  ErrorCode: number;
  Message: string;
};
