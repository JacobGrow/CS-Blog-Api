using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CS_BLOG.Models;
using CS_BLOG.Services;


namespace CS_BLOG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly BlogsService _service;

        private readonly CommentsService _cs;

        public BlogsController(BlogsService service, CommentsService cs)
        {
            _service = service;
            _cs = cs;
        }

        //Get
        [HttpGet]
        public ActionResult<IEnumerable<Blog>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //GetById
        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
              try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //GetCommentsbyBlogId
        [HttpGet("{id}/comments")]
        public ActionResult<IEnumerable<Comment>> GetCommentsByBlogId(int id)
        {
              try
            {
                return Ok(_cs.GetByBlogId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Post
        [HttpPost]
        public ActionResult<Blog> Post([FromBody] Blog newData)
        {
              try
            {
                return Ok(_service.Create(newData));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Put
        [HttpPut("{id}")]
        public ActionResult<Blog> Edit([FromBody] Blog update, int id)
        {
              try
            {
                update.Id = id;
                return Ok(_service.Edit(update));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Delete
        [HttpDelete("{id}")]
        public ActionResult<Blog> Delete(int id)
        {
              try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}