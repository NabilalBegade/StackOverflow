using System;
using System.Collections.Generic;
namespace stackovr
{
    

    public class HomePage
    {
        public List<Question> FeaturedQuestions { get; set; }

        public HomePage()
        {
            FeaturedQuestions = new List<Question>();
        }
    }

   
    public class Question
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Answer> Answers { get; set; }

        public Question(string title, string description, List<Tag> tags)
        {
            Title = title;
            Description = description;
            Tags = tags;
            Answers = new List<Answer>();
        }

        public void AddAnswer(Answer answer)
        {
            Answers.Add(answer);
            Console.WriteLine("Answer added to the question.");
        }

        public void AddComment(string comment)
        {
            // Add code to add comments to the question
            Console.WriteLine($"Comment added: {comment}");
        }


    }

    public class Answer
    {
        public string Content { get; set; }
        public int Votes { get; private set; }
        public Question Question { get; set; }

        public Answer(string content, Question question)
        {
            Content = content;
            Question = question;
            Votes = 0;
        }

        public void VoteUp()
        {
            Votes++;
            Console.WriteLine($"Answer upvoted. Current votes: {Votes}");
        }

        public void VoteDown()
        {
            Votes--;
            Console.WriteLine($"Answer downvoted. Current votes: {Votes}");
        }
    }

    public class Tag
    {
        public string Name { get; set; }

        public Tag(string name)
        {
            Name = name;
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            
           

            Tag tag1 = new Tag("C#");
            Tag tag2 = new Tag("ASP.NET");

            Question question1 = new Question(" C# interfaces?", "I'm new to C# and want to learn about interfaces.", new List<Tag> { tag1 });
            Question question2 = new Question(" ASP.NET Core?", "Can someone explain the basics of ASP.NET Core?", new List<Tag> { tag1, tag2 });

            Answer answer1 = new Answer("Interfaces in C# are used to...", question1);
            Answer answer2 = new Answer("ASP.NET Core is a cross-platform...",  question2);

            question1.AddAnswer(answer1);
            question2.AddAnswer(answer2);

            answer1.VoteUp();
            answer1.VoteUp();
            answer2.VoteDown();

            question2.AddComment("This is a great question!");

            // Create the home page and populate its sections
            HomePage homePage = new HomePage();
            homePage.FeaturedQuestions.Add(question1);
            homePage.FeaturedQuestions.Add(question2);
           

            // Display the home page content
            Console.WriteLine("Welcome to Stack Overflow!");
            Console.WriteLine("Featured Questions:");
            foreach (var i in homePage.FeaturedQuestions)
            {
                Console.WriteLine($"{i.Title} - {i.Description}");
            }




        }
    }
}