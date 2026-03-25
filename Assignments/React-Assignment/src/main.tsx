import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';

import './index.scss';
import App from './App.tsx';
import { StudentFormModalContextProvider } from './contexts/StudentFormModalContext.tsx';
import { CourseFormModalContextProvider } from './contexts/CourseFormModalContext.tsx';

const queryClient = new QueryClient();

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <QueryClientProvider client={queryClient}>
            <CourseFormModalContextProvider>
                <StudentFormModalContextProvider>
                    <App />
                </StudentFormModalContextProvider>
            </CourseFormModalContextProvider>
        </QueryClientProvider>
    </StrictMode>,
);
