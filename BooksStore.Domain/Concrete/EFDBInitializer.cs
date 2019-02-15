using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using BooksStore.Domain.Entities;

namespace BooksStore.Domain.Concrete
{
    public class EFDBInitializer : DropCreateDatabaseIfModelChanges<EFDBContext>
    {
        protected override void Seed(EFDBContext context)
        {
            var genres = new List<Genre>
            {
                new Genre { Name = "C" },
                new Genre { Name = "C#" },
                new Genre { Name = "Cpp" },
                new Genre { Name = "Game" },
                new Genre { Name = "Web" },
                new Genre { Name = "Machine Learning" },
                new Genre { Name = "Java" },
                new Genre { Name = "Python" },
                new Genre { Name = "Data Science" },
                new Genre { Name = "Mobile" }
            };
            genres.ForEach(g => context.Genres.Add(g));

            var authors = new List<Author>
            {
                new Author { Name = "David Griffiths" },
                new Author { Name = "Dawn Griffiths" },
                new Author { Name = "Jared Halpern" },
                new Author { Name = "Nicolai M. Josuttis" },
                new Author { Name = "Onur Gumus" },
                new Author { Name = "Mugilan T.S. Ragupathi" },
                new Author { Name = "Dirk Strauss" },
                new Author { Name = "Jas Rademeyer" },
                new Author { Name = "Mickey MacDonald" },
                new Author { Name = "Jonathan Linowes" },
                new Author { Name = "Matt R. Cole" },
                new Author { Name = "Edward Sciore" },
                new Author { Name = "Cay S. Horstmann" },
                new Author { Name = "Herbert Schildt" },
                new Author { Name = "Robert Johansson" },
                new Author { Name = "Rajat Mehta" },
                new Author { Name = "Russell Fustino" },
                new Author { Name = "Mark L. Murphy" },
                new Author { Name = "Paul Barry" },
                new Author { Name = "Lee Vaughan" },
                new Author { Name = "Nick McClure" },
                new Author { Name = "Luis Pedro Coelho" },
                new Author { Name = "Wilhelm Richert" },
                new Author { Name = "Marcin Moskala" },
                new Author { Name = "Igor Wojda" },
                new Author { Name = "Lyza Danger Gardner" },
                new Author { Name = "Jason Grigsby" },
                new Author { Name = "Mathieu Nayrolles" },
            };
            authors.ForEach(a => context.Authors.Add(a));

            var books = new List<Book>
            {
                new Book
                {
                    Title = "Head First C",
                    Description = "Ever wished there was an easier way to learn C from a book?" +
                    " Head First C is a complete learning experience that will show you how to create programs in the C language",
                    PagesNumber = 632,
                    PublicationYear = 2012,
                    Price = 10.75m,
                    Genres = genres.Where(g => g.Name == "C").ToList(),
                    Authors = authors.Where(a => a.Name == "David Griffiths" || a.Name == "Dawn Griffiths").ToList()
                },
                new Book
                {
                    Title = "Developing 2D Games with Unity",
                    Description = "Follow a walkthrough of the Unity Engine and learn important 2D-centric lessons in scripting, " +
                    "working with image assets, animations, cameras, collision detection, and state management",
                    PagesNumber = 380,
                    PublicationYear = 2019,
                    Price = 45.17m,
                    Genres = genres.Where(g => g.Name == "C#" || g.Name == "Game").ToList(),
                    Authors = authors.Where(a => a.Name == "Jared Halpern").ToList()
                },
                new Book
                {
                    Title = "The C++ Standard Library",
                    Description = "The C++ standard library provides a set of common classes " +
                    "and interfaces that greatly extend the core C++ language",
                    PagesNumber = 1136,
                    PublicationYear = 2012,
                    Price = 22.44m,
                    Genres = genres.Where(g => g.Name == "Cpp").ToList(),
                    Authors = authors.Where(a => a.Name == "Nicolai M. Josuttis").ToList()
                },
                new Book
                {
                    Title = "ASP.NET Core 2 Fundamentals",
                    Description = "Imagine the boost in business if you can build large, " +
                    "rich web applications with little code and built-in Windows authentication",
                    PagesNumber = 298,
                    PublicationYear = 2018,
                    Price = 39.99m,
                    Genres = genres.Where(g => g.Name == "C#" || g.Name == "Web").ToList(),
                    Authors = authors.Where(a => a.Name == "Onur Gumus" || a.Name == "Mugilan T.S. Ragupathi").ToList()
                },
                new Book
                {
                    Title = "C# 7 and .NET Core 2.0 Blueprints",
                    Description = "Leverage the features of C# 7 and .NET core 2.0 to build real-world .NET core applications",
                    PagesNumber = 428,
                    PublicationYear = 2018,
                    Price = 33.33m,
                    Genres = genres.Where(g => g.Name == "C#").ToList(),
                    Authors = authors.Where(a => a.Name == "Dirk Strauss" || a.Name == "Jas Rademeyer").ToList()
                },
                new Book
                {
                    Title = "Mastering C++ Game Development",
                    Description = "Although many languages are now being used to develop games, " +
                    "C++ remains the standard for professional development",
                    PagesNumber = 333,
                    PublicationYear = 2018,
                    Price = 37.88m,
                    Genres = genres.Where(g => g.Name == "Cpp" || g.Name == "Game").ToList(),
                    Authors = authors.Where(a => a.Name == "Mickey MacDonald").ToList()
                },
                new Book
                {
                    Title = "Unity Virtual Reality Projects",
                    Description = "Unity has become the leading platform for building virtual reality games, applications, " +
                    "and experiences for this new generation of consumer VR devices",
                    PagesNumber = 481,
                    PublicationYear = 2018,
                    Price = 33.33m,
                    Genres = genres.Where(g => g.Name == "C#" || g.Name == "Game").ToList(),
                    Authors = authors.Where(a => a.Name == "Jonathan Linowes").ToList()
                },
                new Book
                {
                    Title = "Hands-On Machine Learning with C#",
                    Description = "Explore supervised and unsupervised learning techniques and " +
                    "add smart features to your applications",
                    PagesNumber = 274,
                    PublicationYear = 2018,
                    Price = 28.98m,
                    Genres = genres.Where(g => g.Name == "C#" || g.Name == "Machine Learning").ToList(),
                    Authors = authors.Where(a => a.Name == "Matt R. Cole").ToList()
                },
                new Book
                {
                    Title = "Java Program Design",
                    Description = "Get a grounding in polymorphism and other fundamental aspects " +
                    "of object-oriented program design and implementation, and learn a subset of design patterns " +
                    "that any practicing Java professional simply must know in today\'s job climate",
                    PagesNumber = 465,
                    PublicationYear = 2019,
                    Price = 45.55m,
                    Genres = genres.Where(g => g.Name == "Java").ToList(),
                    Authors = authors.Where(a => a.Name == "Edward Sciore").ToList()
                },
                new Book
                {
                    Title = "Core Java",
                    Description = "Core Java has long been recognized as the leading, no-nonsense tutorial " +
                    "and reference for experienced programmers who want to write robust Java code for real-world applications",
                    PagesNumber = 1461,
                    PublicationYear = 2019,
                    Price = 59.99m,
                    Genres = genres.Where(g => g.Name == "Java").ToList(),
                    Authors = authors.Where(a => a.Name == "Cay S. Horstmann").ToList()
                },
                new Book
                {
                    Title = "Java: A Beginner\'s Guide",
                    Description = "Thoroughly updated for the Java Standard Edition 11 platform, " +
                    "this is a practical guide from the first chapter step by step showing how to start programming on Java",
                    PagesNumber = 814,
                    PublicationYear = 2018,
                    Price = 44.30m,
                    Genres = genres.Where(g => g.Name == "Java").ToList(),
                    Authors = authors.Where(a => a.Name == "Herbert Schildt").ToList()
                },
                new Book
                {
                    Title = "Numerical Python",
                    Description = "Leverage the numerical and mathematical modules in Python " +
                    "and its standard library as well as popular open source numerical Python packages like " +
                    "NumPy, SciPy, FiPy, matplotlib and more",
                    PagesNumber = 700,
                    PublicationYear = 2019,
                    Price = 31.70m,
                    Genres = genres.Where(g => g.Name == "Python" || g.Name == "Data Science").ToList(),
                    Authors = authors.Where(a => a.Name == "Robert Johansson").ToList()
                },
                new Book
                {
                    Title = "Big Data Analytics with Java",
                    Description = "This book covers case studies, such as analyzing sentiments in a tweet dataset, " +
                    "recommendations for a data set from MovieLens, customer segmentation in an e-commerce dataset, " +
                    "and analyzing the schedule of an actual flight data set",
                    PagesNumber = 418,
                    PublicationYear = 2017,
                    Price = 29.60m,
                    Genres = genres.Where(g => g.Name == "Java" || g.Name == "Data Science").ToList(),
                    Authors = authors.Where(a => a.Name == "Rajat Mehta").ToList()
                },
                new Book
                {
                    Title = "Azure and Xamarin Forms",
                    Description = "Discover how to create cross platform apps for Android, " +
                    "iOS and UWP using Azure services and C# with Xamarin Forms",
                    PagesNumber = 271,
                    PublicationYear = 2018,
                    Price = 41.11m,
                    Genres = genres.Where(g => g.Name == "C#" || g.Name == "Mobile").ToList(),
                    Authors = authors.Where(a => a.Name == "Russell Fustino").ToList()
                },
                new Book
                {
                    Title = "Android\'s Architecture Components",
                    Description = "Thanks for your interest in Android app development, " +
                    "the world\'s most popular operating system! And, thanks for your interest " +
                    "in the Android Architecture Components, released by Google in 2017 to help address common " +
                    "\"big-ticket\" problems in Android app development",
                    PagesNumber = 338,
                    PublicationYear = 2018,
                    Price = 40.00m,
                    Genres = genres.Where(g => g.Name == "Mobile").ToList(),
                    Authors = authors.Where(a => a.Name == "Mark L. Murphy").ToList()
                },
                new Book
                {
                    Title = "Head First Python",
                    Description = "Ever wished you could learn Python from a book? " +
                    "Head First Python is a complete learning experience for Python that helps you learn " +
                    "the language through a unique method that goes beyond syntax and how-to manuals, " +
                    "helping you understand how to be a great Python programmer",
                    PagesNumber = 494,
                    PublicationYear = 2010,
                    Price = 10.19m,
                    Genres = genres.Where(g => g.Name == "Python").ToList(),
                    Authors = authors.Where(a => a.Name == "Paul Barry").ToList()
                },
                new Book
                {
                    Title = "Impractical Python Projects",
                    Description = "Impractical Python Projects is a collection of fun and educational projects designed " +
                    "to entertain programmers while enhancing their Python skills",
                    PagesNumber = 478,
                    PublicationYear = 2019,
                    Price = 32.45m,
                    Genres = genres.Where(g => g.Name == "Python").ToList(),
                    Authors = authors.Where(a => a.Name == "Lee Vaughan").ToList()
                },
                new Book
                {
                    Title = "TensorFlow Machine Learning Cookbook",
                    Description = "Skip the theory and get the most out of Tensorflow " +
                    "to build production-ready machine learning models",
                    PagesNumber = 422,
                    PublicationYear = 2018,
                    Price = 33.33m,
                    Genres = genres.Where(g => g.Name == "Python" || g.Name == "Machine Learning").ToList(),
                    Authors = authors.Where(a => a.Name == "Nick McClure").ToList()
                },
                new Book
                {
                    Title = "Building Machine Learning Systems with Python",
                    Description = "Machine learning allows systems to learn things without being explicitly " +
                    "programmed to do so",
                    PagesNumber = 444,
                    PublicationYear = 2018,
                    Price = 42.25m,
                    Genres = genres.Where(g => g.Name == "Python" || g.Name == "Machine Learning").ToList(),
                    Authors = authors.Where(a => a.Name == "Luis Pedro Coelho" || a.Name == "Wilhelm Richert").ToList()
                },
                new Book
                {
                    Title = "Android Development with Kotlin",
                    Description = "Nowadays, improved application development " +
                    "does not just mean building better performing applications",
                    PagesNumber = 440,
                    PublicationYear = 2017,
                    Price = 29.99m,
                    Genres = genres.Where(g => g.Name == "Mobile").ToList(),
                    Authors = authors.Where(a => a.Name == "Marcin Moskala" || a.Name == "Igor Wojda").ToList()
                },
                new Book
                {
                    Title = "Head First Mobile Web",
                    Description = "Mobile web usage is exploding. Soon, more web browsing " +
                    "will take place on phones and tablets than PCs",
                    PagesNumber = 480,
                    PublicationYear = 2012,
                    Price = 17.77m,
                    Genres = genres.Where(g => g.Name == "Mobile" || g.Name == "Web").ToList(),
                    Authors = authors.Where(a => a.Name == "Lyza Danger Gardner" || a.Name == "Jason Grigsby").ToList()
                },
                new Book
                {
                    Title = "Angular Design Patterns",
                    Description = "Make the most of Angular by leveraging design patterns and best practices " +
                    "to build stable and high performing apps",
                    PagesNumber = 178,
                    PublicationYear = 2018,
                    Price = 22.22m,
                    Genres = genres.Where(g => g.Name == "Web").ToList(),
                    Authors = authors.Where(a => a.Name == "Mathieu Nayrolles").ToList()
                }
            };
            books.ForEach(b => context.Books.Add(b));

            base.Seed(context);
        }
    }
}