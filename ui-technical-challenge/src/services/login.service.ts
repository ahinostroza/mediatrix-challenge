import api from "./config/api"

export const loginService = {
    signIn: async (username: string, password: string) => {
        return await api.post('/login', { username, password })
    },
    signOut: async () => {
        return await api.post('/logout')
    }
}