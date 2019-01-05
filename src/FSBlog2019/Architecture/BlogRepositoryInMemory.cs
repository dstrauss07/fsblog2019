using System;
using System.Collections.Generic;
using System.Text;
using StraussDA.ApplicationCore.Entities;
using StraussDA.ApplicationCore.Interfaces;

namespace StraussDA.Architecture
{
    public class BlogRepositoryInMemory : IBlogRepository
    {
        public static List<BlogPost> _blogPosts;
        private static int _nextId = 1;
        
        public BlogRepositoryInMemory()
        {
            if(_blogPosts == null)
            {
                _blogPosts = new List<BlogPost>();
            }
        }

        public void Add(BlogPost newBlogPost)
        {
            newBlogPost.Id = _nextId++;
            _blogPosts.Add(newBlogPost);
        }

        public void Delete(BlogPost deletedBlogPost)
        {
            var origBlogPost = GetById(deletedBlogPost.Id);
            _blogPosts.Remove(origBlogPost);
        }

        public void Edit(BlogPost editedBlogPost)
        {
            var origBlogPost = GetById(editedBlogPost.Id);
            origBlogPost.Author = editedBlogPost.Author;
            origBlogPost.CreatedDateTime = editedBlogPost.CreatedDateTime;
            origBlogPost.Post = editedBlogPost.Post;
        }

        public BlogPost GetById(int id)
        {
            return _blogPosts.Find(b => b.Id == id);
        }

        public List<BlogPost> ListAll()
        {
            return _blogPosts;

        }
    }
}
