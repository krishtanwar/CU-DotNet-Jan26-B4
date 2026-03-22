using AutoMapper;
using LoanManagementDTO.DTOs;
using LoanManagementDTO.Models;
namespace LoanManagementDTO.Mappings

{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<LoanCreateDTO, Loan>();
            CreateMap<LoanUpdateDTO, Loan>();

            CreateMap<Loan, LoanReadDTO>();
        }
    }
}
