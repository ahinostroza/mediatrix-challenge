namespace SB.TechnicalChallenge.Domain;

public class Organism : Entity
{
    public string Name { get; private set; }

    public void Register(Guid id, string name)
    {
        Id = id;
        Name = name;
        IsActive = true;
    }

    public void Update(string name)
    {
        Name = name;
    }

    public void Delete()
    {
        IsActive = false;
    }
}
