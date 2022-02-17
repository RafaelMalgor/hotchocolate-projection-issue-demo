namespace SchemaFirst.Data;

public class PersonRepository
{
    private readonly PersonDbContext context;

    public PersonRepository(PersonDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Person> GetPersons()
    {
        return this.context.Persons;
    }
}