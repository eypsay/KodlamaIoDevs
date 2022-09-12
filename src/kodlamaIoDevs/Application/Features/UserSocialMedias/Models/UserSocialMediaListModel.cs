using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.UserSocialMedias.Models
{
    public class UserSocialMediaListModel : BasePageableModel
    {
        public IList<UserSocialMedia> Items { get; set; }
    }
}
