using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _NorskOrd_.Data;
using _NorskOrd_.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace _NorskOrd_.Services
{
    public interface INorskOrd
    {
        AddNewWordDto GetById(int id);
        IEnumerable<AddNewWordDto> GetAll();
        int Create(AddNewWordDto dto);
        bool Delete(int id);
        bool Update(int id, UpdateWordDto dto);
    }

    public class NorskOrdService : INorskOrd
    {
        private readonly NorskOrdDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<NorskOrdService> _logger;

        public NorskOrdService(NorskOrdDBContext dBcontext, IMapper mapper, ILogger<NorskOrdService> logger)
        {
            _dbContext = dBcontext;
            _mapper = mapper;
            _logger = logger;
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

        public bool Update(int id, UpdateWordDto dto)
        {
            var word = _dbContext
                .Words
                .FirstOrDefault(w => w.Id == id);

            if (word is null) return false;

            word.WordsToLearn = dto.WordsToLearn;
            word.WordsTranslated = dto.WordsTranslated;

            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            _logger.LogError($"Word with id: {id} DELETE action invoked");

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
