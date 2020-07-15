using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using CS_BLOG.Models;
using Dapper;

namespace CS_BLOG.Repositories
{
  public class CommentsRepository
  {
      private readonly IDbConnection _db;
      public CommentsRepository(IDbConnection db)
      {
          _db = db;
      }
    internal IEnumerable<Comment> GetByBlogId(int id)
    {
      string sql =@"SELECT * FROM comments WHERE blogId = @id";
      return _db.Query<Comment>(sql, new { id });
    }

    internal Comment GetById(int id)
    {
      string sql =@"SELECT * FROM comments WHERE id = @id";
      return _db.QueryFirstOrDefault<Comment>(sql, new { id });
    }

    internal Comment Create(Comment newData)
    {
      string sql =@"
      INSERT INTO comments
      (author, body, blogId)
      VALUES
      (@Author, @body, @BlogId);
      SELECT LAST_INSERT_ID();
      ";
      newData.Id = _db.ExecuteScalar<int>(sql, newData){
          return newData;
      }
    }

    internal object Edit(Comment original)
    {
      string sql =@"
      UPDATE comments 
      SET 
        body = @Body
      WHERE id = @Id
      SELECT * FROM comments WHERE id = @Id";
      return _db.QueryFirstOrDefault<Comment>(sql, original);
    }

    internal bool Delete(int id)
    {
      string sql =@"DELETE FROM comments WHERE id = @id LIMIT 1;";
      int affected = _db.Execute(sql, new { id });
      return affected == 1;
    }
  }
}