namespace Questionnaire_API.Services
{
    public class PaginationMetadata
    {
        public int totalItemCount { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }

        public PaginationMetadata(int totalItemCount, int pageSize, int pageNumber)
        {
            this.totalItemCount = totalItemCount;
            this.pageSize = pageSize;
            this.pageNumber = pageNumber;
        }
    }
}