import { ErrorInfo, Fragment, StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { RouterProvider } from 'react-router-dom'
import { Slide, ToastContainer } from 'react-toastify'
import { router } from './routes/index.tsx'
import 'react-toastify/dist/ReactToastify.css';
import './index.css'

createRoot(document.getElementById('root')!, {
  onRecoverableError: (error: any, errorInfo: ErrorInfo) => {
    console.error(
      'Recoverable error',
      error,
      error?.cause,
      errorInfo.componentStack,
    )
  }
}).render(
  <StrictMode>
    <Fragment>
      <RouterProvider router={router} />
      <ToastContainer
        transition={Slide}
        hideProgressBar={true}
        position='bottom-left'
        draggableDirection='y'
        theme='colored'
      />
    </Fragment>
  </StrictMode>,
)
