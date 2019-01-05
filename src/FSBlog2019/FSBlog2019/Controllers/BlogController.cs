using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StraussDA.ApplicationCore.Entities;
using StraussDA.ApplicationCore.Interfaces;

namespace Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepo;

        public BlogController(IBlogRepository blogRepo)
        {
            _blogRepo = blogRepo;
        }
        // GET: Blog
        public ActionResult Index()
        {
            return View(_blogRepo.ListAll());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            return View(_blogRepo.GetById(id));
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View(new BlogPost());
        }

        // POST: Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogPost newBlogPost)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _blogRepo.Add(newBlogPost);
                    return RedirectToAction(nameof(Index));
                }

             }
            catch(Exception)
            {
               // TODO log the exception
            }
            return View(newBlogPost);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_blogRepo.GetById(id));
        }

        // POST: Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BlogPost editedBlogPost)
        {
            try
            {
                _blogRepo.Edit(editedBlogPost);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                //TODO log exception
            }
            return View(editedBlogPost);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_blogRepo.GetById(id));
        }

        // POST: Blog/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BlogPost deletedBlogPost)
        {
            try
            {
                _blogRepo.Delete(deletedBlogPost);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
               //TODO log the exception
            }
            return View(deletedBlogPost);
        }
    }
}