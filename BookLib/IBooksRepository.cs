using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public interface IBooksRepository
    {
        /// <summary>
        /// Get() skal give mulighed for at filtrere på Price.
        /// Get() skal give mulighed for at sortere på Title eller Price.
        /// Returnerer en kopi af listen af alle Book objekter: Brug en copy constructor.
        /// </summary>
        /// <returns>List<Book></returns>
        List<Book> Get();
        /// <summary>
        /// Returnerer Book objektet med det angivne id - eller null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Book</returns>
        Book GetById(int id);
        /// <summary>
        /// Tilføjer id til  book objektet. Tilføjer book til listen. Returnerer book objektet
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Book</returns>
        Book Add(Book book);
        /// <summary>
        /// Sletter book objektet med det angivne id. Returnerer book objektet - eller null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Book</returns>
        Book Delete(int id);
        /// <summary>
        /// Book objektet med det angivne id opdateres med values.
        /// Returnerer det opdaterede book objekt - eller null.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns>Book</returns>
        Book Update(int id, Book book);

    }
}
