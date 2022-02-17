namespace SchemaFirst.DTOs
{
    /// <summary>
    /// This class intentionally has the "Dto" suffix for debugging, so we can easily know 
    /// if we are working with the DTO and not the Entity.
    /// </summary>
    public class PersonDto
    {
        public int? IdDto { get; set; }
        public string? NameDto { get; set; }
        public string? LastNameDto { get; set; }
    }
}
