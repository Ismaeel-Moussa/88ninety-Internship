import axios from 'axios';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import type { StudentResponse } from '../../types/Student';

const deleteStudent = async (id: number): Promise<StudentResponse> => {
    const response = await axios.delete(
        `${import.meta.env.VITE_API_URL}/students/${id}`,
    );
    console.log(response.data);
    return response.data;
};

const useDeleteStudent = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: deleteStudent,
        onSettled: () => {
            queryClient.invalidateQueries({
                queryKey: ['students'],
                exact: false,
            });
        },
    });
};

export default useDeleteStudent;
