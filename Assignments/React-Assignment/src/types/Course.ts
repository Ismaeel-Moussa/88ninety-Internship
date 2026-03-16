export interface Course {
    id: number;
    name: string;
    credit: number;
}

export interface GetCoursesResponse {
    message: string | null;
    result: Course[];
}
