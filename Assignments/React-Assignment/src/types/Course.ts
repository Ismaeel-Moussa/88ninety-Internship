export interface Course {
    id: number;
    name: string;
    credit: number;
}

export interface GetCoursesResponse {
    version: string | null;
    statusCode: string | number;
    message: string | null;
    isError: boolean | null;
    responseException: string | null;
    result: Course[];
}
