using System;
using System.Collections.Generic;
using CS_BLOG.Models;
using CS_BLOG.Repositories;

namespace CS_BLOG.Services
{
  public class BlogsService
  {

    private readonly BlogsRepository _repo;
    public BlogsService(BlogsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Blog> Get()
    {
      return _repo.Get();
    }

    public Blog Get(int blogId)
    {
      Blog exists = _repo.GetById(blogId);
      if(exists == null) { throw new Exception ("Invalid Id partner"); }
      return exists;
    }

    internal Blog Create(Blog newBlog)
    {
      int id = _repo.Create(newBlog);
      newBlog.Id = id;
      return newBlog;
    }

    public Blog Edit(Blog editBlog)
    {
      Blog original = Get(editBlog.Id);
      original.Title = editBlog.Title.Length > 0 ? editBlog.Title : original.Title;
      original.Description = editBlog.Description.Length > 0 ? editBlog.Description : original.Description;
      return _repo.Edit(original);

    }

    internal object Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}