export interface Course {
    id: number;
    name: string;
    credit: number;
}

export interface GetCoursesResponse {
    statusCode: number | null;
    result: Course[];
    isError: boolean | null;
    message: string | null;
    responseException: string | null;
    version: string | null;
}
