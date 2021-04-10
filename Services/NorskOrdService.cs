using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _NorskOrd_.Data;
using AutoMapper;

namespace _NorskOrd_.Services
{
    public interface INorskOrd
    {
        AddNewWordDto GetById(int id);
        IEnumerable<AddNewWordDto> GetAll();
        int Create(AddNewWordDto dto);
        public bool Delete(int id);
    }

    public class NorskOrdService : INorskOrd
    {
        private readonly NorskOrdDBContext _dbContext;
        private readonly IMapper _mapper;

        public NorskOrdService(NorskOrdDBContext dBcontext, IMapper mapper)
        {
            _dbContext = dBcontext;
            _mapper = mapper;
        }
        public AddNewWordDto GetById(int id)
        {
            var word = _dbContext
                .Words
                .FirstOrDefault(w => w.Id == id);

            if (word is null) return null;
            var result = _mapper.Map<AddNewWordDto>(word);
            return result;
        }

        public IEnumerable<AddNewWordDto> GetAll()
        {
            var words = _dbContext
                .Words
                .ToList();

            var WordsDtos = _mapper.Map<List<AddNewWordDto>>(words);
            return WordsDtos;
        }

        public bool Delete(int id)
        {
            var word = _dbContext
                .Words
                .FirstOrDefault(w => w.Id == id);

            if (word is null) return false;

            _dbContext.Words.Remove(word);
            _dbContext.SaveChanges();

            return true;
        }

        public int Create(AddNewWordDto dto)
        {
            var word = _mapper.Map<Words>(dto);
            _dbContext.Words.Add(word);
            _dbContext.SaveChanges();

            return word.Id;
        }
    }
}
