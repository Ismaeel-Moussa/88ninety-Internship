export interface Course {
    id?: number;
    name: string;
    credit: string;
}

export interface GetCoursesResponse {
    statusCode: number | null;
    result: Course[];
    isError: boolean | null;
    message: string | null;
    responseException: string | null;
    version: string | null;
}

export interface CourseResponse {
    statusCode: number | null;
    result: Course | null;
    isError: boolean | null;
    message: string | null;
    responseException: string | null;
    version: string | null;
}
