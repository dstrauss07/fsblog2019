using System;
using System.Collections.Generic;
using System.Text;
using StraussDA.ApplicationCore.Entities;

namespace StraussDA.ApplicationCore.Interfaces
{
   public interface IBlogRepository
    {
        List<BlogPost> ListAll();
        BlogPost GetById(int id);
        void Add(BlogPost newBlogPost);
        void Edit(BlogPost editedBlogPost);
        void Delete(BlogPost deletedBlogPost);
    }
}
