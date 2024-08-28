using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;
using Volo.Abp.Identity;
using Volo.Abp.Uow;

namespace Sabeco_Factsheet.TbUsers
{
    public class UserUpdatedEventHandler :
        ILocalEventHandler<EntityUpdatedEventData<IdentityUser>>,
        ITransientDependency
    { 
        private readonly ITbUserRepository _tbUserRepository;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IdentityUserManager _identityUserManager;

        public UserUpdatedEventHandler(
            IdentityUserManager identityUserManager,
            IIdentityUserRepository identityUserRepository,
            ITbUserRepository tbUserRepository)
        { 
            _identityUserManager = identityUserManager;
            _identityUserRepository = identityUserRepository;
            _tbUserRepository = tbUserRepository;
        }

        public async Task HandleEventAsync(EntityUpdatedEventData<IdentityUser> eventData)
        {
            try
            {
                var existingUser = await _tbUserRepository.GetByAbpUserIdAsync(eventData.Entity.Id);

                if (existingUser == null)
                {
                    Console.WriteLine("User not found.");
                    return;
                }

                // Kiểm tra xem có sự thay đổi trong các trường dữ liệu và cập nhật chỉ khi có thay đổi
                if (existingUser.FullName != eventData.Entity.Name + " " + eventData.Entity.Surname ||
                    existingUser.Email != eventData.Entity.Email ||
                    existingUser.IsActive != eventData.Entity.IsActive || 
                    existingUser.UserName != eventData.Entity.UserName ||
                    existingUser.UserPrincipalName != eventData.Entity.Email)
                {
                    existingUser.FullName = eventData.Entity.Name;
                    existingUser.Email = eventData.Entity.Email;
                    existingUser.IsActive = eventData.Entity.IsActive; 
                    existingUser.UserName = eventData.Entity.UserName;
                    existingUser.UserPrincipalName = eventData.Entity.Email; 
                    existingUser.FullName = eventData.Entity.Name + eventData.Entity.Surname;

                    await _tbUserRepository.UpdateAsync(existingUser);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating User: {ex.Message}");
            }
        } 

    }

}