import { createBrowserRouter } from "react-router-dom";

import { Layout } from "../components/Layout";
import { constant } from "../utils/constants";
import { lazy } from "react";

const Login = lazy(() => import("../views/Login"))

export const router = createBrowserRouter([
    {
        path: constant.LOGIN,
        element: <Login />
    },
    {
        element: <Layout />,
        path: constant.HOME,
        children: [
            {
                path: constant.CONSULT,
                element: <div></div>
            },
            {
                path: constant.REGISTER,
                element: <div></div>
            }
        ],
        // errorElement: <NotFound />
    }
])