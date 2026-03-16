export interface Student {
    id: number;
    name: string;
    email: string;
}

export interface GetStudentsResponse {
    message: string | null;
    result: Student[];
}
