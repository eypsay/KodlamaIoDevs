using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class UserSocialMedia : Entity
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public virtual User? User { get; set; }

        public UserSocialMedia()
        {

        }

        public UserSocialMedia(int id, int userId, string githubUrl, User? user) : this()
        {
            Id = id;
            UserId = userId;
            GithubUrl = githubUrl;

        }
    }
}
