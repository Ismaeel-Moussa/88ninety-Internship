export interface Student {
    id?: number;
    name: string;
    email: string;
}

export interface GetStudentsResponse {
    statusCode: number | null;
    result: Student[];
    isError: boolean | null;
    message: string | null;
    responseException: string | null;
    version: string | null;
}
export interface StudentResponse {
    statusCode: number | null;
    result: Student | null;
    isError: boolean | null;
    message: string | null;
    responseException: string | null;
    version: string | null;
}
