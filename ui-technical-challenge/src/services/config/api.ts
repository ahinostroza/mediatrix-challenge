import { AxiosRequestConfig } from 'axios'
import axios from './interceptor'

const api = {
    get: async <T>(url: string, config?: AxiosRequestConfig) => {
        return await axios.get<T>(url, config)
    },
    post: async <T>(url: string, data?: any, config?: AxiosRequestConfig) => {
        return await axios.post<T>(url, data, config)
    },
    delete: async <T>(url: string, config?: AxiosRequestConfig) => {
        return await axios.delete<T>(url, config)
    },
    put: async <T>(url: string, config?: AxiosRequestConfig) => {
        return await axios.put<T>(url, config)
    }
}

export default api