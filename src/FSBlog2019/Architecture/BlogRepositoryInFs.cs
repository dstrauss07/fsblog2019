using System;
using System.Collections.Generic;
using System.Text;
using StraussDA.ApplicationCore.Entities;
using StraussDA.ApplicationCore.Interfaces;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace StraussDA.Architecture
{
    public class BlogRepositoryInFs : IBlogRepository
    {
        public static List<BlogPost> _blogPosts;
        private static int _nextId = 1;

        private const string PATH = "/blogdata";
        private const string FILENAME = "blogdata.json";

        private readonly string _fileFullPath = Path.Combine(PATH, FILENAME);

        
        public BlogRepositoryInFs()
        {
            if(_blogPosts == null)
            {
                _blogPosts = LoadFile();
             //   _nextId = _blogPosts.Max(b => b.Id) + 1;
            }
        }

        public void Add(BlogPost newBlogPost)
        {
            newBlogPost.Id = _nextId++;
            _blogPosts.Add(newBlogPost);
            SaveFile();
        }

        public void Delete(BlogPost deletedBlogPost)
        {
            var origBlogPost = GetById(deletedBlogPost.Id);
            _blogPosts.Remove(origBlogPost);
            SaveFile();
        }

        public void Edit(BlogPost editedBlogPost)
        {
            var origBlogPost = GetById(editedBlogPost.Id);
            origBlogPost.Author = editedBlogPost.Author;
            origBlogPost.CreatedDateTime = editedBlogPost.CreatedDateTime;
            origBlogPost.Post = editedBlogPost.Post;
            SaveFile();
        }

        public BlogPost GetById(int id)
        {
            return _blogPosts.Find(b => b.Id == id);
        }

        public List<BlogPost> ListAll()
        {
            return _blogPosts;

        }

        public List<BlogPost> LoadFile()
        {
            try
            {
                string rawListStr = File.ReadAllText(_fileFullPath);
                List<BlogPost> rawBlogList = JsonConvert.DeserializeObject<List<BlogPost>>(rawListStr);

                return rawBlogList;
            }
            catch(Exception)
            {
                //TODO log the exception
                return new List<BlogPost>();
            }
        }

        public void SaveFile()
        {
            try
            {
                if(!Directory.Exists(PATH))
                {
                    Directory.CreateDirectory(PATH);
                }
            string rawListStr = JsonConvert.SerializeObject(_blogPosts);
            File.WriteAllText(_fileFullPath, rawListStr);
            }
           
            
            catch(Exception)
            {
                //TODO log the exception
            }
        }
    }
}
