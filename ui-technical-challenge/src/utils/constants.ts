const path = {
    HOME: '/',
    LOGIN: '/login',
    CONSULT: '/consult',
    REGISTER: '/register'
}

const rol = {
    ADMINISTRADOR: 'Administrador'
}

const statusCode = {
    UNAUTHORIZED: 401
}

export const constant = {
    ...path,
    ...rol,
    ...statusCode
}