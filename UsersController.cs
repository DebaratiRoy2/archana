﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using UserRegistration.Entity;
using UserRegistration.Business;
using System.Web.Http.Cors;

namespace UserRegistration.Controllers
{
    //[EnableCors(origins: "", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private readonly UserManager userManager = new UserManager();
        private readonly FindMyRoom_DatabaseEntities db = new FindMyRoom_DatabaseEntities();


        //GET: api/Users
        

        public async Task<User> GetUsers(int id)
        {
            return await userManager.GetUserDetails(id);
        }
        [HttpPut]
        [Route("api/Users/PutUser")]
        public async Task<int> PutUser(User user)
        {
            return await userManager.PutUser(user);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}



//// GET: api/Users/5
//[ResponseType(typeof(User))]
//public async Task<IHttpActionResult> GetUser(int id)
//{
//    User user = await db.Users.FindAsync(id);
//    if (user == null)
//    {
//        return NotFound();
//    }

//    return Ok(user);
//}

// PUT: api/Users/5
//[ResponseType(typeof(void))]
//public async Task<IHttpActionResult> PutUser(int id, User user)
//{
//    if (!ModelState.IsValid)
//    {
//        return BadRequest(ModelState);
//    }

//    if (id != user.UserId)
//    {
//        return BadRequest();
//    }

//    db.Entry(user).State = EntityState.Modified;

//    try
//    {
//        await db.SaveChangesAsync();
//    }
//    catch (DbUpdateConcurrencyException)
//    {
//        if (!UserExists(id))
//        {
//            return NotFound();
//        }
//        else
//        {
//            throw;
//        }
//    }

//    return StatusCode(HttpStatusCode.NoContent);
//}
// POST: api/Users
//[ResponseType(typeof(User))]
//public async Task<IHttpActionResult> PostUser(User user)
//{  
//if (!ModelState.IsValid)
//{
//    return BadRequest(ModelState);
//}

//db.Users.Add(user);
//await db.SaveChangesAsync();

//return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);

//// DELETE: api/Users/5
//[ResponseType(typeof(User))]
//public async Task<IHttpActionResult> DeleteUser(int id)
//{
//    User user = await db.Users.FindAsync(id);
//    if (user == null)
//    {
//        return NotFound();
//    }

//    db.Users.Remove(user);
//    await db.SaveChangesAsync();

//    return Ok(user);
//}

//protected override void Dispose(bool disposing)
//{
//    if (disposing)
//    {
//        db.Dispose();
//    }
//    base.Dispose(disposing);
//}

