using System.ComponentModel;

namespace PawMates.API.Contracts
{
    public class CreatePostRequest
    {
        [DefaultValue("3aa42229-1c0f-4630-8c1a-db879ecd0427")]
        public Guid UserId { get; set; }
        [DefaultValue("Post Title")]
        public string Title { get; set; } = "Default Title";
        [DefaultValue("This is the default content for the post.")]
        public string Content { get; set; } = "Default Content";
    }
}
