export type ApiResponse<T> = {
  Data: T;
  ErrorCode: number;
  Message: string;
};
