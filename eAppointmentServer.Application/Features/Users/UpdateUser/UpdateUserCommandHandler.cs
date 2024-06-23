using AutoMapper;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Users.UpdateUser;

internal sealed class UpdateUserCommandHandler(
    UserManager<AppUser> userManager,
    IUserRoleRepository userRoleRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByIdAsync(request.Id.ToString());
        if (user is null)
        {
            return Result<string>.Failure("Kullanıcı kaydı bulunamadı");
        }

        if(user.Email != request.Email)
        {
            if (await userManager.Users.AnyAsync(p => p.Email == request.Email))
            {
                return Result<string>.Failure("E-posta adresi zaten var");
            }
        }
        
        if(user.UserName != request.UserName)
        {
            if (await userManager.Users.AnyAsync(p => p.UserName == request.UserName))
            {
                return Result<string>.Failure("Kullanıcı adı zaten var");
            }
        }       

        mapper.Map(request, user);
        IdentityResult result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return Result<string>.Failure(result.Errors.Select(s => s.Description).ToList());
        }


        if (request.RoleIds.Any())
        {
            List<AppUserRole> userRoles = await userRoleRepository.Where(p=> p.UserId == user.Id).ToListAsync();
            userRoleRepository.DeleteRange(userRoles);           
            await unitOfWork.SaveChangesAsync(cancellationToken);

            userRoles = new();

            foreach (var roleId in request.RoleIds)
            {
                AppUserRole userRole = new()
                {
                    RoleId = roleId,
                    UserId = user.Id
                };
                userRoles.Add(userRole);
            }

            await userRoleRepository.AddRangeAsync(userRoles, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        return "Kullanıcı kaydı başarı ile güncellendi";
    }
}
