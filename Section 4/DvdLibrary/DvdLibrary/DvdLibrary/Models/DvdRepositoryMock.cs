using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrary.Models
{
    public class DvdRepositoryMock: IDvdRepository
    {
        private static List<Dvd> _dvds;

        static DvdRepositoryMock()
        {
            _dvds = new List<Dvd>()
            {
                new Dvd { DvdId=1, Title="Jaws", ReleaseYear=1975, Director="Steven Spielberg", Rating="PG", Notes="A giant shark eats people." },
                new Dvd { DvdId=2, Title="ET", ReleaseYear=1982, Director="Steven Spielberg", Rating="PG", Notes="A troubled child summons the courage to help a friendly alien." },
                new Dvd { DvdId=3, Title="Alien", ReleaseYear=1979, Director="Ridley Scott", Rating="R", Notes="Aliens attack a crew in space." },
                new Dvd { DvdId=4, Title="Star Wars: A New Hope", ReleaseYear=1977, Director="George Lucas", Rating="PG", Notes="Luke Skywalker joins forces with a Jedi Knight." },
            };
        }
        public List<Dvd> GetAll()
        {
            return _dvds;
        }

        public Dvd Get(int dvdId)
        {
            return _dvds.FirstOrDefault(d => d.DvdId == dvdId);
        }

        public List<Dvd> GetbyTitle(string title)
        {
            return _dvds.FindAll(d => d.Title == title);
        }

        public void Create(Dvd newDvd)
        {
            if (_dvds.Any())
            {
                newDvd.DvdId = _dvds.Max(d => d.DvdId) + 1;
            }
            else
            {
                newDvd.DvdId = 0;
            }

            _dvds.Add(newDvd);
        }

        public void Update(Dvd updatedDvd)
        {
            _dvds.RemoveAll(d => d.DvdId == updatedDvd.DvdId);
            _dvds.Add(updatedDvd);
        }

        public void Delete(int dvdId)
        {
            _dvds.RemoveAll(d => d.DvdId == dvdId);
        }

        public List<Dvd> GetbyYear(int releaseYear)
        {
            return _dvds.FindAll(d => d.ReleaseYear == releaseYear);
        }

        public List<Dvd> GetbyDirector(string director)
        {
            return _dvds.FindAll(d => d.Director == director);
        }

        public List<Dvd> GetbyRating(string rating)
        {
            return _dvds.FindAll(d => d.Rating == rating.ToUpper());
        }
    }
}