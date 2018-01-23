using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.HR;

namespace WangYc.Models.Repository.HR
{
    public interface IOrganizationRepository : IRepository<Organization, int> {
    }
}
