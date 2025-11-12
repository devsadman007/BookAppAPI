using AutoMapper;
using BookAppAPI.CommandQueries;
using BookAppAPI.Domain;

namespace BookAppAPI.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Command to Domain
            CreateMap<BookCommand, Book>();

            // Domain to Query
            CreateMap<Book, BookQuery>();
        }
    }
}
