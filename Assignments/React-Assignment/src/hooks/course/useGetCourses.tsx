import axios from 'axios';
import { useQuery, type UseQueryResult } from '@tanstack/react-query';
import type { Course, GetCoursesResponse } from '../../types/Course';

const fetchCourses = async (): Promise<Course[]> => {
    const result = await axios.get<GetCoursesResponse>(
        `${import.meta.env.VITE_API_URL}/courses`,
    );
    console.log(result.data);
    return result.data.result;
};

const useGetCourses = (): UseQueryResult<Course[]> => {
    const query = useQuery({
        queryKey: ['courses'],
        queryFn: fetchCourses,
        staleTime: 1000 * 10,
    });
    return query;
};

export default useGetCourses;
