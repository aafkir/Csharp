using System;
using System.Collections.Generic;
using System.Text;

namespace PublicationDeLivres
{
    public enum PublicationType { Diverse, Book, Magazine, Article };

    public abstract class Publication
    {
        private bool published = false;
        private DateTime datePublished;
        private int totalPages;

        public bool IsCopyright { get; private set; } = false;
        public string Publisher { get; }
        public string Title { get; }
        public PublicationType Type { get; }
        public string CopyrightName { get; private set; }
        public int CopyrightYear { get; private set; }

        // Le constructeur
        public Publication(string title, string publisher, PublicationType type)
        {
            if (String.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Le titre de la publication est obligatoire" +
                                        "(au moins un caractère différent de l'espace blanc)");
            Title = title;

            if (String.IsNullOrWhiteSpace(publisher))
                throw new ArgumentException("Le nom d'Editeur de la publication est obligatoire" +
                    "(au moins un caractère différent de l'espace blanc)");
            Publisher = publisher;

            Type = type;
        }

        public int Pages
        {
            get { return totalPages; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Le nombre de pages doit être supérieur strict à 0");
                }
                totalPages = value;
            }
        }

        // retourne la date de publication 
        public string GetPublicationDate()
        {
            if (!published)
            {
                return "PEP"; // PEP : Pas Encore Publié
            }
            else
            {
                return datePublished.ToString();
            }
        }

        // effectuer la publication (autoriser la publication et enregistrer la date de publication)
        public void Publish(DateTime datePublished)
        {
            published = true;
            this.datePublished = datePublished;
        }

        // attribuer le nom et l'année du Copyrigth de la publication
        public void Copyright(string copyrightName, int copyrightYear)
        {
            if (String.IsNullOrWhiteSpace(copyrightName))
            {
                throw new ArgumentException("Le nom du Copyright est obligatoire (au moins un caractère différent de l'espace blanc)");
            }
            CopyrightName = copyrightName;
            int currentYear = DateTime.Now.Year;
            if (copyrightYear < currentYear)
            {
                throw new ArgumentOutOfRangeException("La date du Copyright doit être supérieure ou égale à " + currentYear);
            }
            CopyrightYear = copyrightYear;
            IsCopyright = true;
        }

        //public override string ToString()
        //{
        //    return Title;
        //}
        public override string ToString() => Title;

    }
}
