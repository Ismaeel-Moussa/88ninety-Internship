import axios from 'axios';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import type { CourseResponse } from '../../types/Course';

const deleteCourse = async (id: number): Promise<CourseResponse> => {
    const response = await axios.delete(
        `${import.meta.env.VITE_API_URL}/Courses/${id}`,
    );
    console.log(response.data);
    return response.data;
};

const useDeleteCourse = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: deleteCourse,
        onSettled: () => {
            queryClient.invalidateQueries({
                queryKey: ['courses'],
                exact: false,
            });
        },
    });
};

export default useDeleteCourse;
