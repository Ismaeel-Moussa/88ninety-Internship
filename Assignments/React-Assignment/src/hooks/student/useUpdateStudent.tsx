import axios from 'axios';
import type { StudentResponse, Student } from '../../types/Student';
import { useMutation, useQueryClient } from '@tanstack/react-query';

const updateStudent = async (student: Student): Promise<StudentResponse> => {
    const { id, ...body } = student;
    if (!id) throw new Error('Student id is required for update');
    const response = await axios.put(
        `${import.meta.env.VITE_API_URL}/students/${id}`,
        body,
    );
    console.log(response.data);
    return response.data;
};

const useUpdateStudent = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: updateStudent,

        onMutate: async (updatedStudent) => {
            await queryClient.cancelQueries({ queryKey: ['students'] });
            const previousStudents = queryClient.getQueryData<Student[]>([
                'students',
            ]);
            queryClient.setQueryData<Student[]>(['students'], (currentData) =>
                currentData
                    ? currentData.map((s) =>
                          s.id === updatedStudent.id ? updatedStudent : s,
                      )
                    : [updatedStudent],
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

export default useUpdateStudent;
