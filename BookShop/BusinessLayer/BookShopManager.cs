using AutoMapper;
using BusinessLayer.ModelsDTO;
using DataAccess;
using DataAccess.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class BookShopManager
    {
        public readonly BookShopRepository _bookShopRepository;

        private readonly Mapper _mapper;
        public BookShopManager()
        {
            _bookShopRepository = new BookShopRepository();

            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<Writer, WriterDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<BookDTO, Book>();
                cfg.CreateMap<WriterDTO, Writer>();
                cfg.CreateMap<CategoryDTO, Category>();

            });

            _mapper = new Mapper(conf);
        }

        public IList<BookDTO>GetAllBooks()
        {
            return _mapper.Map<IList<BookDTO>>(_bookShopRepository.GetAllBooks());
        }

        public void AddBook(BookDTO bookDto, WriterDTO writerDto, CategoryDTO categoryDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var writer = _mapper.Map<Writer>(writerDto);
            var category = _mapper.Map<Category>(categoryDto);

            _bookShopRepository.AddBook(book, writer, category);
        }

        public void RemoveBookById(int id)
        {
            _bookShopRepository.RemoveBookById(id);
        }

        public void UpdateBook(BookDTO bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);          

            _bookShopRepository.UpdateBook(book);
        }

        public BookDTO GetBookById(int id)
        {
            return _mapper.Map<BookDTO>(_bookShopRepository.GetBookById(id));
        }

        public IList<CategoryDTO>CreateListCategories()
        {
            return _mapper.Map<IList<CategoryDTO>>(_bookShopRepository.CreateListCategories());
        }
    }
}
