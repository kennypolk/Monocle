﻿using Monocle.Repository.Entities;
using Monocle.Repository.Interfaces;
using Monocle.Services.Interfaces;

namespace Monocle.Services.Services
{
    public class PostService : RestService<Post>, IPostService
    {
        public PostService(IPostRepository repository) : base(repository)
        {
        }
    }
}
