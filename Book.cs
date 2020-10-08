using System;
using System.Collections.Generic;
using System.Text;

namespace PublicationDeLivres
{
    // sealed : signifie que cette classe ne peut pas avoir de classe fille => c'est une classe finale
    public sealed class Book : Publication
    {
        private ulong uISBN = 1234567890123;
        public ulong ISBN { get; set; }
        public string Author { get; set; }
        public float Price { get; private set; }
        public string Currency { get; private set; } // symbole de la devise en 3 caractères

        public Book(string title, string author, string publisher) :
            this(title, String.Empty, author, publisher)
        {
        }

        public Book(string title, string isbn, string author, string publisher) :
    base(title, author, PublicationType.Book)
        {
            if (!String.IsNullOrEmpty(isbn))
            {
                if (!(isbn.Length == 10 | isbn.Length == 13))
                    throw new ArgumentException("L'ISBN doit être en 10 ou 13 chiffres");
                try
                {
                    ISBN = ulong.Parse(isbn);
                }
                catch (FormatException ex)
                {
                    throw new FormatException(ex.Message);
                }

            }
            else
            {
                ISBN = GenerateIsbn();
            }
            if (String.IsNullOrEmpty(author))
                throw new ArgumentException("L'auteur du livre est obligatoire.");
            Author = author;
        }


        public void SetPrice(float price, string currency)
        {
            if (price <= 0)
                throw new ArgumentOutOfRangeException("Le prix du livre ne peut pas être négatif ou égal à zéro");
            Price = price;

            if (currency.Length != 3)
                throw new ArgumentException("Le symbole de la devise doit être en 3 caractères");
            Currency = currency;
        }

        public ulong GenerateIsbn()
        {
            return uISBN++;
        }

        public override string ToString() => "Titre : " + Title + " - Auteur : " + Author + " - Editeur : " +
                                                    Publisher + " - ISBN : " + ISBN;

    }
}
