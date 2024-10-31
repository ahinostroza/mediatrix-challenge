import { Link, useLocation } from 'react-router-dom'
import { constant } from '../../utils/constants'
import { useStore } from '../../store'

export const Nav = () => {
    const location = useLocation()
    const { updateName } = useStore((state) => state)
    const isActive = (path: string) => location.pathname === path ? 'bg-[#5279934d]' : '';

    const handleChange = (name: string) => {
        console.log(name)
        updateName({ name })
    }
    
    return (
        <nav className='w-96 h-full p-5'>
            <div>
                <img src="menu.svg" alt="" />
            </div>
            <div className='mt-4'>
                <ul>
                    <li>
                        <Link to={constant.HOME} onChange={() => handleChange('Inicio')} className={`flex items-center gap-4 p-4 hover:bg-[#5279934d] rounded-xl ${isActive(constant.HOME)}`}>
                            <img src="home.svg" alt="" />
                            <span className='text-white font-semibold'>Inicio</span>
                        </Link>
                    </li>
                    <li>
                        <Link to={constant.CONSULT} onChange={() => handleChange('Consulta')} className={`p-4 block hover:bg-[#5279934d] rounded-xl ${isActive(constant.CONSULT)}`}>
                            <span className='text-white font-semibold'>Consulta</span>
                        </Link>
                    </li>
                    <li>
                        <Link to={constant.REGISTER} onChange={() => handleChange('Crear registro')} className={`p-4 block hover:bg-[#5279934d] rounded-xl ${isActive(constant.REGISTER)}`}>
                            <span className='text-white font-semibold'>Crear registro</span>
                        </Link>
                    </li>
                </ul>
            </div>
        </nav>
    )
}