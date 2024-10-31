import React from "react"
import { useNavigate } from "react-router-dom"
import { SubmitHandler, useForm } from "react-hook-form"

// import { Button } from "@/components/Button"
// import { ILogin } from "@/models/login.interface"
// import { loginService } from "@/services/login.service"

import { toast } from "react-toastify"
import { loginService } from "../../services/login.service"
import { ILogin } from "../../models/login.interface"
import { Button } from "../../components/Button"

const Login = () => {
    const navigate = useNavigate()
    const [loading, setLoading] = React.useState(false)

    const { register, handleSubmit } = useForm<ILogin>()

    const onSubmit: SubmitHandler<ILogin> = async (data) => {
        setLoading(true)
        const { username, password } = data
        await loginService.signIn(username, password)
            .then(({ data: token }: any) => {
                localStorage.setItem('access_token', token)
                toast.success(`Inicio de sesion: Exitoso`)
                navigate('/')
            })
            .catch(error => {
                const { response } = error
                toast.error(`Error to sign in: ${(response as any)?.data?.Message}`)
                console.error(error)
            })
            .finally(() => {
                setLoading(false)
            })
    }

    return (
        <div className="flex min-h-full flex-1 flex-col justify-center px-6 py-12 lg:px-8">
            <div className="sm:mx-auto sm:w-full sm:max-w-sm">
                <img
                    src="logo.svg"
                    alt="Logo"
                />
                <h2 className="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-white">
                    Iniciar Sesion
                </h2>
            </div>

            <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
                <form className="space-y-6" onSubmit={handleSubmit(onSubmit)} >
                    <div>
                        <label htmlFor="username" className="block text-sm font-medium leading-6 text-white">
                            Usuario
                        </label>
                        <div className="mt-2">
                            <input
                                id="username"
                                type="text"
                                {...register('username', { required: true })}
                                autoComplete="username"
                                required
                                className="block w-full rounded-md border-0 px-1.5 py-1.5 text-primary shadow-sm ring-1 placeholder:text-gray focus:ring-2 focus:ring-primary focus:ring-indigo-600 sm:text-sm sm:leading-6 outline-none"
                            />
                        </div>
                    </div>

                    <div>
                        <div className="flex items-center justify-between">
                            <label htmlFor="password" className="block text-sm font-medium leading-6 text-white">
                                Contraseña
                            </label>
                            <div className="text-sm">
                                <a href="#" className="font-semibold text-white">
                                    Olvidaste la contraseña?
                                </a>
                            </div>
                        </div>
                        <div className="mt-2">
                            <input
                                id="password"
                                type="password"
                                {...register('password', { required: true })}
                                autoComplete="current-password"
                                required
                                className="block w-full rounded-md border-0 px-1.5 py-1.5 text-primary shadow-sm ring-1 placeholder:text-gray focus:ring-2 focus:ring-primary focus:ring-indigo-600 sm:text-sm sm:leading-6 outline-none"
                            />
                        </div>
                    </div>

                    <div className="mx-auto max-w-40">
                        <Button
                            title="Comencemos"
                            loading={loading}
                        />
                    </div>
                </form>
            </div >
        </div >
    )
}

export default Login