import axios from 'axios';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import type { studentResponse } from '../../types/Student';

const deleteStudent = async (id: number): Promise<studentResponse> => {
    const response = await axios.delete(
        `http://localhost:5212/api/students/${id}`,
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
