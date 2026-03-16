export interface Student {
    id: number;
    name: string;
    email: string;
}

export interface GetStudentsResponse {
    version: null;
    statusCode: number;
    message: null;
    isError: null;
    responseException: null;
    result: Student[];
}
