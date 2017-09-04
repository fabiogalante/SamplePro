using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using SamplePro.Models;

namespace SamplePro.Controllers
{
    [Produces("application/json")]
    //[Route("api/Post")]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly ApiContext _db;


        public PostController(ApiContext db)
        {
            _db = db ;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._db.Posts.ToList());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(this._db.Posts.FirstOrDefault(p => p.Id == id));
        }

        //[HttpPost]
        //public IActionResult Post([FromBody] Post post)
        //{
        //    this._db.Posts.Add(post);
        //    _db.SaveChanges();

        //    return Created("Get", post);
        //}



        [HttpPost]
        public HttpResponseMessage Post([FromBody] Post post)
        {

            try
            {
                _db.Posts.Add(post);


                if (_db.SaveChanges() > 0)
                {
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {

                return new HttpResponseMessage(HttpStatusCode.BadRequest); 
            }


          
        }


        [HttpPut]
        public HttpResponseMessage Put([FromRoute] int id, [FromBody] Post post)
        {

            try
            {
                Post po = _db.Posts.FirstOrDefault(p => p.Id == id);

                if (po == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }


                po.Title = post.Title;
                po.Description = post.Description;
                po.PostImage = post.PostImage;



                if (_db.SaveChanges() > 0)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }



        }


        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Post po = _db.Posts.FirstOrDefault(e => e.Id == id);

                if (po == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                _db.Posts.Remove(po);

                if (_db.SaveChanges() > 0)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }

                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}