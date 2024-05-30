using System;

class Program
{
    static void Main(string[] args)
    {
        // Create 3 videos
        List<Video> _videos = new List<Video>
        {
            new Video("Video 1", "Creator A", 120),
            new Video("Video 2", "Creator B", 180),
            new Video("Video 3", "Creator A", 240)
        };

        // Add comments to each video
        _videos[0]._comments.Add(new Comment("User 1", "Great video!" ));
        _videos[0]._comments.Add(new Comment("User 2", "I learned a lot from this."));
        _videos[0]._comments.Add(new Comment("User 3", "Awesome content!"));

        _videos[1]._comments.Add(new Comment("User 4", "Informative and engaging."));
        _videos[1]._comments.Add(new Comment("User 5", "Loved the production quality."));
        _videos[1]._comments.Add(new Comment("User 6", "Can't wait for more videos like this."));

        _videos[2]._comments.Add(new Comment("User 7", "Fantastic video, Thank you!"));
        _videos[2]._comments.Add(new Comment("User 8", "I subscribed after watching this."));
        _videos[2]._comments.Add(new Comment("User 9", "This is my new favorite channel."));

        // Display information for each video
        foreach (var _video in _videos)
        {
            Console.WriteLine($"Title: {_video._title}");
            Console.WriteLine($"Author: {_video._author}");
            Console.WriteLine($"Length: {_video._length} seconds");
            Console.WriteLine($"Number of comments: {_video.GetCommentCount()}");
            Console.WriteLine("Comments: ");
            foreach (var _comment in _video._comments)
            {
                Console.WriteLine($"- {_comment._commenter}: {_comment._text}");
            }
            Console.WriteLine();
        }
    }

    
}