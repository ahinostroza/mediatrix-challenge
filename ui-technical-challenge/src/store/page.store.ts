import { StateCreator } from 'zustand'

type State = {
    name: string
}

type Action = {
    updateName: (name: State) => void
}

export interface PageSlice extends State, Action {}

export const createPageSlice: StateCreator<PageSlice> = (set) => ({
    name: '',
    updateName: (page: State) => set(() => ({ ...page }))
})