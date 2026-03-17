import axios from 'axios';
import type { AddStudentResponse, Student } from '../../types/Student';
import { useMutation, useQueryClient } from '@tanstack/react-query';

const requestData = async (student: Student): Promise<AddStudentResponse> => {
    const response = await axios.post(
        'http://localhost:5212/api/students',
        student,
    );

    return response.data;
};

const useAddStudent = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: requestData,
        onSettled: () => {
            queryClient.invalidateQueries({
                queryKey: ['students'],
                exact: false,
            });
        },
    });
};

export default useAddStudent;
