interface IUser {
    name: string
    email: string
    imageUrl: string
}

interface IUserNavigation {
    name: string
    href: string
    onClick: () => void
}

export interface INav {
    // user: IUser
    userNavigation: IUserNavigation[]
}