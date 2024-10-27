namespace CarBook.WebUI.Areas.Admin.DTOs.CommentDtos
{
    public class ResultCommentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}
