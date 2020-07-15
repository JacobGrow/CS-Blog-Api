using CS_BLOG.Services;
using CS_BLOG.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CS_BLOG.Controllers
{
    public class CommentsController : ControllerBase
    {
        private readonly CommentsService _service;

        public CommentsController(CommentsService service)
        {
            _service = service;
        }

        //Get
     

        //GetById
        [HttpGet("{id}")]
        public ActionResult<Comment> Get(int id)
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

        //Post
        [HttpPost]
        public ActionResult<Comment> Post([FromBody] Comment newData)
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
        public ActionResult<Comment> Edit([FromBody] Comment update, int id)
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
        public ActionResult<Comment> Delete(int id)
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