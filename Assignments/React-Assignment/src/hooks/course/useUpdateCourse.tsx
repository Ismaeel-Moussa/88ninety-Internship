import axios from 'axios';
import type { CourseResponse, Course } from '../../types/Course';
import { useMutation, useQueryClient } from '@tanstack/react-query';

const updateCourse = async (Course: Course): Promise<CourseResponse> => {
    const { id, ...body } = Course;
    if (!id) throw new Error('Course id is required for update');
    const response = await axios.put(
        `${import.meta.env.VITE_API_URL}/Courses/${id}`,
        body,
    );
    console.log(response.data);
    return response.data;
};

const useUpdateCourse = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: updateCourse,

        onMutate: async (updatedCourse) => {
            await queryClient.cancelQueries({ queryKey: ['courses'] });
            const previousCourses = queryClient.getQueryData<Course[]>([
                'courses',
            ]);
            queryClient.setQueryData<Course[]>(['courses'], (currentData) =>
                currentData
                    ? currentData.map((s) =>
                          s.id === updatedCourse.id ? updatedCourse : s,
                      )
                    : [updatedCourse],
            );

            return { previousCourses };
        },

        onError: (_err, _newCourse, context) => {
            if (context?.previousCourses != null) {
                queryClient.setQueryData(['courses'], context.previousCourses);
            }
        },
        onSettled: () => {
            queryClient.invalidateQueries({
                queryKey: ['courses'],
                exact: false,
            });
        },
    });
};

export default useUpdateCourse;
