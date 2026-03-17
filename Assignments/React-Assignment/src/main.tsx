import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';

import './index.scss';
import App from './App.tsx';
import { StudentFormModalContextProvider } from './contexts/StudentFormModalContext.tsx';

const queryClient = new QueryClient();

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <QueryClientProvider client={queryClient}>
            <StudentFormModalContextProvider>
                <App />
            </StudentFormModalContextProvider>
        </QueryClientProvider>
    </StrictMode>,
);
