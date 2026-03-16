export interface Student {
    id: number;
    name: string;
    email: string;
}

export interface GetStudentsResponse {
    version: string | null;
    statusCode: string | number;
    message: string | null;
    isError: boolean | null;
    responseException: string | null;
    result: Student[];
}
