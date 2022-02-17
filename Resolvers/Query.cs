using HotChocolate.Resolvers;
using SchemaFirst.Data;

namespace Demo.Resolvers;

public class Query
{
    [UseProjection]
    [UseFiltering]
    public IQueryable<SchemaFirst.DTOs.PersonDto> GetPersons(
        [Service] PersonRepository repository,
        IResolverContext context)
    {
        return repository.GetPersons().ProjectTo<Person, SchemaFirst.DTOs.PersonDto>(context);
    }

}
