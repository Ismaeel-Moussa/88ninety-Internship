import axios from 'axios';
import type { CourseResponse, Course } from '../../types/Course';
import { useMutation, useQueryClient } from '@tanstack/react-query';

const requestData = async (Course: Course): Promise<CourseResponse> => {
    const response = await axios.post(
        `${import.meta.env.VITE_API_URL}/Courses`,
        Course,
    );
    console.log(response.data);
    return response.data;
};

const useAddCourse = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: requestData,

        onMutate: async (newCourse) => {
            await queryClient.cancelQueries({ queryKey: ['Courses'] });
            const previousCourses = queryClient.getQueryData<Course[]>([
                'Courses',
            ]);
            queryClient.setQueryData<Course[]>(['Courses'], (currentData) =>
                currentData ? [...currentData, newCourse] : [newCourse],
            );

            return { previousCourses };
        },

        onError: (_err, _newCourse, context) => {
            if (context?.previousCourses != null) {
                queryClient.setQueryData(['Courses'], context.previousCourses);
            }
        },

        onSettled: () => {
            queryClient.invalidateQueries({
                queryKey: ['Courses'],
                exact: false,
            });
        },
    });
};

export default useAddCourse;
