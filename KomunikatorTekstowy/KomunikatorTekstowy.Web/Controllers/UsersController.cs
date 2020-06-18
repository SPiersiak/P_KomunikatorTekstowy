using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KomunikatorTekstowy.Web.Models;

namespace KomunikatorTekstowy.Web.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository ItemRepository;

        public UsersController(IUsersRepository itemRepository)
        {
            ItemRepository = itemRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<UserDetailData>> List()
        {
            return ItemRepository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDetailData> GetItem(string id)
        {
            UserDetailData item = ItemRepository.Get(id);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserDetailData> Create([FromBody]UserDetailData item)
        {
            ItemRepository.Add(item);
            return CreatedAtAction(nameof(GetItem), new { item.UserId }, item);
        }

        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult Edit([FromBody] UserDetailData item)
        //{
        //    try
        //    {
        //        ItemRepository.Update(item);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Error while editing item");
        //    }
        //    return NoContent();
        //}
        [HttpPost("{id}")]
        public void Post([FromBody] UserDetailData value)
        {

            ItemRepository.Update(value);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(string id)
        {
            UserDetailData item = ItemRepository.Remove(id);

            if (item == null)
                return NotFound();

            return Ok();
        }
    }
}