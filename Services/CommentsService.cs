using System;
using System.Collections;
using CS_BLOG.Models;
using CS_BLOG.Repositories;

namespace CS_BLOG.Services
{
  public class CommentsService
  {
    private readonly CommentsRepository _repo;
    public CommentsService(CommentsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable GetByBlogId(int id)
    {
      return _repo.GetByBlodId(id);
    }
    internal Comment Get(int id)
    {
      Comment exists = _repo.GetById(id);
      if(exists == null) { throw new Exception ("Invalid Id partner"); }
      return exists;
    }

    internal Comment Create(Comment newData)
    {
      return _repo.Create(newData);
    }

    internal Comment Edit(Comment update)
    {
      Comment original = Get(update.Id);
      original.Body = update.Body;
      return _repo.Edit(original);
    }

    internal Comment Delete(int id)
    {
      Comment toDelete = Get(id);
      if(!_repo.Delete(id)){
        throw new UnauthorizedAccessException("Invalid Access");
      }
      return toDelete;
    }

  }
}