using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CS_BLOG.Models;
using CS_BLOG.Services;


namespace CS_BLOG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController :ControllerBase
    {
        private readonly BlogsService _service;

        public BlogsController(BlogsService service)
        {
            _service = service;
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
        [HttpGet("{blogId}")]
        public ActionResult<Blog> Get(int blogId)
        {
              try
            {
                return Ok(_service.Get(blogId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Post
        [HttpPost]
        public ActionResult<Blog> Post([FromBody] Blog newBlog)
        {
              try
            {
                return Ok(_service.Create(newBlog));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Put
        [HttpPut("{id}")]
        public ActionResult<Blog> Edit([FromBody] Blog newBlog, int id)
        {
              try
            {
                return Ok(_service.Edit(newBlog));
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