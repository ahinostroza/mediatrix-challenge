import { Suspense } from "react"
import { Navigate, Outlet } from "react-router-dom"

import { Header } from "../Header"
import { Nav } from "../Nav"

export const Layout = () => {
    const token = localStorage.getItem('access_token')

    return (
        <div className="flex min-h-full">
            <Nav />
            <div className="flex flex-col flex-1">
                <Header name='Nombre de la pagina' />
                <main className="flex-1 rounded-t-3xl bg-gray">
                    <div className="m-10 h-52 bg-white rounded-2xl">
                        <Suspense fallback='Loading...'>
                            {token ? <Outlet /> : <Navigate to="/login" />}
                        </Suspense>
                    </div>
                </main>
            </div>
        </div>
    )
}