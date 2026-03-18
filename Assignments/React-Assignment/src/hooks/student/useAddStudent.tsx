import axios from 'axios';
import type { studentResponse, Student } from '../../types/Student';
import { useMutation, useQueryClient } from '@tanstack/react-query';

const requestData = async (student: Student): Promise<studentResponse> => {
    const response = await axios.post(
        'http://localhost:5212/api/students',
        student,
    );
    console.log(response.data);
    return response.data;
};

const useAddStudent = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: requestData,

        onMutate: async (newStudent) => {
            await queryClient.cancelQueries({ queryKey: ['students'] });
            const previousStudents = queryClient.getQueryData<Student[]>([
                'students',
            ]);
            queryClient.setQueryData<Student[]>(['students'], (currentData) =>
                currentData ? [...currentData, newStudent] : [newStudent],
            );

            return { previousStudents };
        },

        onError: (_err, _newStudent, context) => {
            if (context?.previousStudents != null) {
                queryClient.setQueryData(
                    ['students'],
                    context.previousStudents,
                );
            }
        },

        onSettled: () => {
            queryClient.invalidateQueries({
                queryKey: ['students'],
                exact: false,
            });
        },
    });
};

export default useAddStudent;
