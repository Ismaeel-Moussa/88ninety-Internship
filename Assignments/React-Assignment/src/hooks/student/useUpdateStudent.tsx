import axios from 'axios';
import type { studentResponse, Student } from '../../types/Student';
import { useMutation, useQueryClient } from '@tanstack/react-query';

const updateStudent = async (student: Student): Promise<studentResponse> => {
    const { id, ...body } = student;
    if (!id) throw new Error('Student id is required for update');
    const response = await axios.put(
        `http://localhost:5212/api/students/${id}`,
        body,
    );
    console.log(response.data);
    return response.data;
};

const useUpdateStudent = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: updateStudent,
        onSettled: () => {
            queryClient.invalidateQueries({
                queryKey: ['students'],
                exact: false,
            });
        },
    });
};

export default useUpdateStudent;
