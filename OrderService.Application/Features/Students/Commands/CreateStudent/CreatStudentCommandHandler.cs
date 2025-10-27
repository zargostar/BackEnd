using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Contracts;
using OrderService.Application.Features.Students.Queries.EfTest;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Application.Features.Students.Commands.CreateStudent
{
    public class CreatStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        private UserManager<AppUser> userManager;
        private readonly ICurrentUser currentUser;

        public CreatStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper, UserManager<AppUser> userManager, ICurrentUser currentUser)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
            this.userManager = userManager;
            this.currentUser = currentUser;
        }

        public async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            //var userid = currentUser.UserId;
            //var appUser =await userManager.FindByIdAsync(userid);
            //if(request.SportStudents.Any())
            //{
            //    var clam = new Claim("hassport", "true", ClaimValueTypes.Boolean);
            //  var result=  await userManager.AddClaimAsync(appUser, clam);
            //    //if(!result.Succeeded)
            //    //{
            //    //    throw new BadRequestObjectResult(result.Errors.Select(err => err.Description));
            //    //}

            //}
            //var cc= await userManager.GetClaimsAsync(appUser);
        //  userManager.RemoveClaimAsync()
           var newStudent = mapper.Map<Student>(request);
            await studentRepository.AddAsync(newStudent);
            // var data=await studentRepository.GetByIdAsync(newStudent.Id);
            //  var data2=await studentRepository.GetAsync(p=> EF.Functions.Like( p.Name,"%pp%"));
            //var data20=await studentRepository.GetAsync(p=>p.Images.Any(p=> EF.Functions.Like(p,"r")));
            var xx = await studentRepository.GetAsync(p => p.Name.Contains("r"));
            var dd =await studentRepository.GetAsync(p => p.Images.Any(p=> p.Contains("r")));
            //var dd0 = studentRepository.GetAsync(p => p.Images.Any(p=> p.Contains("%r%")));
            
           // var data21=await studentRepository.GetAsync(p=>p.Images.Any(p=> EF.Functions.Like(p,"%r%")));
            //var res = data21;

            
        }
    }
}
