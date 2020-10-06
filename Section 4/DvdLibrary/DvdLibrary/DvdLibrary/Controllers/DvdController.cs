using DvdLibrary.Factories;
using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibrary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        IDvdRepository dvdRepository = DvdRepositoryFactory.GetRepository();

        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(dvdRepository.GetAll());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            Dvd found = dvdRepository.Get(id);

            if (found == null)
                return NotFound();

            return Ok(found);
        }

        [Route("dvd/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(Dvd dvd)
        {
            dvdRepository.Create(dvd);

            return Created($"dvd/{dvd.DvdId}", dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(int id, Dvd dvd)
        {
            dvdRepository.Update(dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            dvdRepository.Delete(id);
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetbyTitle(string title)
        {
            List<Dvd> found = dvdRepository.GetbyTitle(title);

            if (found == null)
                return NotFound();

            return Ok(found);
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetbyYear(int releaseYear)
        {
            List<Dvd> found = dvdRepository.GetbyYear(releaseYear);

            if (found == null)
                return NotFound();

            return Ok(found);
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetbyDirector(string director)
        {
            List<Dvd> found = dvdRepository.GetbyDirector(director);

            if (found == null)
                return NotFound();

            return Ok(found);
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetbyRating(string rating)
        {
            List<Dvd> found = dvdRepository.GetbyRating(rating);

            if (found == null)
                return NotFound();

            return Ok(found);
        }
    }
}

