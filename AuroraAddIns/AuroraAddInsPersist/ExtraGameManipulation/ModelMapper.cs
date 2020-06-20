using Aurora.AddInsInterfacing.AuroraCore.Models;
using Aurora.AddInsPersist.DatabaseModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddInsPersist.ExtraGameManipulation
{
    public class ModelMapper
    {
        public TechObject TechObjectFromDb(DbTechObject theDbData)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DbTechObject, TechObject>());
            var mapper = new Mapper(config);
            var model = mapper.Map<TechObject>(theDbData);
            return model;
        }

        public List<TechObject> TechObjectFromDb(List<DbTechObject> theDbDataList)
        {
            var resultList = new List<TechObject>();
            foreach (var fromObject in theDbDataList)
            {
                resultList.Add(this.TechObjectFromDb(fromObject));
            }
            return resultList;
        }

        public DbTechObject TechObjectToDb(TechObject theObject)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TechObject, DbTechObject>());
            var mapper = new Mapper(config);
            var model = mapper.Map<DbTechObject>(theObject);
            return model;
        }

        public TechType TechTypeFromDb(DbTechType theDbData)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DbTechType, TechType>());
            var mapper = new Mapper(config);
            var model = mapper.Map<TechType>(theDbData);
            return model;
        }

        public List<TechType> TechTypeFromDb(List<DbTechType> theDbDataList)
        {
            var resultList = new List<TechType>();
            foreach (var fromObject in theDbDataList)
            {
                resultList.Add(this.TechTypeFromDb(fromObject));
            }
            return resultList;
        }
    }
}
