using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DvdLibrary.Models
{
    public class DvdRepositoryEF : IDvdRepository
    {
        static DvdLibraryEntities repository = new DvdLibraryEntities();
        IEnumerable<Dvd> dvds = repository.Dvds;
      
        public void Create(Dvd newDvd)
        {
            if (dvds.Any())
            {
                newDvd.DvdId = dvds.Max(d => d.DvdId) + 1;
            }
            else
            {
                newDvd.DvdId = 0;
            }

            repository.Dvds.Add(newDvd);
            repository.SaveChanges();
        }

        public void Delete(int dvdId)
        {
            Dvd dvd = dvds.FirstOrDefault(d => d.DvdId == dvdId);
            if(dvd != null)
            {
                repository.Dvds.Remove(dvd);
                repository.SaveChanges();
            }
        }

        public Dvd Get(int dvdId)
        {
            return dvds.FirstOrDefault(d => d.DvdId == dvdId);
        }

        public List<Dvd> GetAll()
        {     
            return dvds.ToList();
        }

        public void Update(Dvd updatedDvd)
        {         
            Dvd dvd = dvds.FirstOrDefault(d => d.DvdId == updatedDvd.DvdId);
            repository.Entry(dvd).CurrentValues.SetValues(updatedDvd);
            repository.SaveChanges();              
        }

        public List<Dvd> GetbyTitle(string title)
        {
            List<Dvd> dvdList = dvds.Where(d => d.Title.Contains(title)).ToList();
            return dvdList;
        }

        public List<Dvd> GetbyYear(int releaseYear)
        {
            return dvds.Where(d => d.ReleaseYear == releaseYear).ToList();
        }

        public List<Dvd> GetbyDirector(string director)
        {
            List<Dvd> dvdList = dvds.Where(d => d.Director.Contains(director)).ToList();
            return dvdList;
        }

        public List<Dvd> GetbyRating(string rating)
        {
            return dvds.Where(d => d.Rating == rating.ToUpper()).ToList();
        }
    }
}