using System;
using static System.Console;

namespace PublicationDeLivres
{
    class ProgramPrincipal
    {
        static void Main(string[] args)
        {
            Book book = new Book("Les misérables", "9876543210", "Victor HUGO", "Hachettes Collection");
            AfficherInfosDePublication(book);

            book.Publish(DateTime.Now);
            AfficherInfosDePublication(book);

            book.Copyright("Doranco", 2020);
            AfficherInfosDePublication(book);

            Magazine magazine = new Magazine();
            AfficherInfosDePublication(magazine);
        }
        public static void AfficherInfosDePublication(Publication pub)
        {
            string publicationDate = pub.GetPublicationDate();
            WriteLine(pub.Title + " : "
                        + (publicationDate == "PEP" ? "Pas encore publié" : ("publié le " + publicationDate + " par " + pub.Publisher))
                        + (pub.IsCopyright ? (" / Copyright : " + pub.CopyrightName + " - Année : " + pub.CopyrightYear) : "No Copyright")
                     );
        }
    }
}
