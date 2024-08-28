using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Sabeco_Factsheet.TbUsers
{
    public class UserDeletedEventHandler : 
        ILocalEventHandler<EntityDeletedEventData<IdentityUser>>,
        ITransientDependency
    {
        private readonly ITbUserRepository _tbUserRepository;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IdentityUserManager _identityUserManager;

        public UserDeletedEventHandler(IIdentityUserRepository identityUserRepository,
            IdentityUserManager identityUserManager,
            ITbUserRepository tbUserRepository)
        {
            _identityUserRepository = identityUserRepository;
            _identityUserManager = identityUserManager;
            _tbUserRepository = tbUserRepository;
        }
         
        public async Task HandleEventAsync(EntityDeletedEventData<IdentityUser> eventData)
        {
            try
            {
                var existingUser = await _tbUserRepository.GetByAbpUserIdAsync(eventData.Entity.Id);

                if (existingUser != null)
                {
                    await _tbUserRepository.DeleteAsync(existingUser.Id);
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting User: {ex.Message}");
            }
        }

    }
}
