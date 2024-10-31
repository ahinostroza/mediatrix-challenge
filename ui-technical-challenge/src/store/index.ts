import { create } from "zustand";
import { createJSONStorage, devtools, persist } from "zustand/middleware";
import { createPageSlice, PageSlice } from "./page.store";

export const useStore = create<PageSlice>()(
    devtools(
        persist(
            (...a) => ({
                ...createPageSlice(...a)
            }),
            { 
                name: 'store',
                storage: createJSONStorage(() => sessionStorage),
            },
        )
    )
)