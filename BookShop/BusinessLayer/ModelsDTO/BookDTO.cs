using System.Collections.Generic;

namespace BusinessLayer.ModelsDTO
{
    public class BookDTO
    {
        public BookDTO()
        {
            Writers = new List<WriterDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<WriterDTO> Writers { get; set; }
        public CategoryDTO Category { get; set; }
        public int CategoryId { get; set; }
    }
}
