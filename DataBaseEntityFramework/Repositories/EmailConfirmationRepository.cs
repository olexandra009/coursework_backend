using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IEmailConfirmationRepository : IRepository<EmailConfirmEntity>
    {

    }
    public class EmailConfirmationRepository : EfRepository<EmailConfirmEntity>, IEmailConfirmationRepository
    {
        public EmailConfirmationRepository(PlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
