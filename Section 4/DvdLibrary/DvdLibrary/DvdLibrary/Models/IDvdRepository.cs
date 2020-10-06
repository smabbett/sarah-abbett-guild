using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Models
{
    public interface IDvdRepository
    {
        List<Dvd> GetAll();
        Dvd Get(int dvdId);

        List<Dvd> GetbyTitle(string title);

        List<Dvd> GetbyYear(int releaseYear);

        List<Dvd> GetbyDirector(string director);

        List<Dvd> GetbyRating(string rating);

        void Create(Dvd newDvd);
        void Update(Dvd updatedDvd);
        void Delete(int dvdId);
       
    }
}
