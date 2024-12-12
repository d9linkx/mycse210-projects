using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Here, I created a list to store these videos
        List<Video> videos = new List<Video>();

        // This is the first video I added to the list
        Video video1 = new Video("Introduction to C#", "Chinedu Okafor", 600);
        video1.AddComment(new Comment("Ada", "Great video, so practical!"));
        video1.AddComment(new Comment("Bola", "Very informative especially for students and millenials."));
        video1.AddComment(new Comment("Chika", "Thanks for the tutorial, I cant wait to learn more next week."));
        videos.Add(video1);

        // I'm adding another video to my list
        Video video2 = new Video("Advanced C# Techniques", "Ngozi Adebayo", 1200);
        video2.AddComment(new Comment("David", "This was really helpful jare."));
        video2.AddComment(new Comment("Efe", "I learned a lot, thanks!"));
        video2.AddComment(new Comment("Femi", "Excellent content. Keep it up man."));
        videos.Add(video2);

        // And here's the third video I'm adding
        Video video3 = new Video("C# Design Patterns", "Adebare Sandra", 900);
        video3.AddComment(new Comment("Grace", "These are very clear explanations. Although you could have left the share button open so that we can share to others."));
        video3.AddComment(new Comment("Hassan", "Amazing, loved the examples you shared. How did you do that?"));
        video3.AddComment(new Comment("Ijeoma", "This is a must-watch people in my area, and I wish everyone can practice it and get the desired results. thanks fam"));
        videos.Add(video3);

        // Now, let's go through the list of videos and display their details
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

class Video
{
    private string title;
    private string author;
    private int length; // Length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        this.comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public string Title => title;
    public string Author => author;
    public int Length => length;
    public List<Comment> Comments => comments;
}

class Comment
{
    private string name;
    private string text;

    public Comment(string name, string text)
    {
        this.name = name;
        this.text = text;
    }

    public string Name => name;
    public string Text => text;
}
