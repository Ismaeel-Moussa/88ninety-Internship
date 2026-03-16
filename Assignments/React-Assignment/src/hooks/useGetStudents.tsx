import axios from 'axios';
import type { GetStudentsResponse, Student } from '../types/Student';
import { useQuery, type UseQueryResult } from '@tanstack/react-query';

const fetchStudent = async (): Promise<Student[]> => {
    const result = await axios.get<GetStudentsResponse>(
        'https://localhost:7078/api/students',
    );
    console.log(result.data);
    return result.data.result;
};

const useGetStudents = (): UseQueryResult<Student[]> => {
    const query = useQuery({
        queryKey: ['students'],
        queryFn: fetchStudent,
        staleTime: 1000 * 10,
    });
    return query;
};

export default useGetStudents;
