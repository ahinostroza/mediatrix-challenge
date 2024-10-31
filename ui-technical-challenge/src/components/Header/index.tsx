export const Header = ({ name }: any) => {
    return (
        <header>
            <div className="p-8">
                <h1 className="text-white text-3xl font-semibold">{name}</h1>
            </div>
        </header>
    )
}