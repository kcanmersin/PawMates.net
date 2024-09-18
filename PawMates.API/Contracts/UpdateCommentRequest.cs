namespace PawMates.API.Contracts
{
    public class UpdateCommentRequest
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
