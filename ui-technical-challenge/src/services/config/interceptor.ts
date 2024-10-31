import axios, { AxiosError, AxiosResponse, InternalAxiosRequestConfig } from 'axios'
import { constant } from '../../utils/constants'

export const instance = axios.create({
    baseURL: '/api'
})

instance.interceptors.request.use(
    (config: InternalAxiosRequestConfig) => {
        const token = localStorage.getItem('access_token')
        if (token) {
            config.headers['Authorization'] = `bearer ${token}`
        }
        return config
    },
    (error: AxiosError) => {
        return Promise.reject(error)
    }
)

instance.interceptors.response.use(
    (response: AxiosResponse) => response,
    (error: AxiosError) => {
        if(error.response?.status === constant.UNAUTHORIZED) {
            localStorage.removeItem('access_token')
            window.location.href = '/login'
            return Promise.reject(error)
        }
        return Promise.reject(error)
    }
)

export default instance