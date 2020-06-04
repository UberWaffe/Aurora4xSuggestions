using Aurora.AddInsInterfacing.ExtraGameManipulation.Interface;
using Aurora.AddInsInterfacing.ExtraGameManipulation.Models;
using Aurora.AddInsPersist.DatabaseModels;
using Aurora.AddInsPersist.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddInsPersist.ExtraGameManipulation
{
    public class GameManipPersistentStorage : IGameManipPersistentStorage
    {
        private SQLiteDatabase databaseHandler;
        private ModelMapper _mapper;

        public GameManipPersistentStorage()
        {
            this.databaseHandler = new SQLiteDatabase();
            this._mapper = new ModelMapper();
        }

        public List<TechObject> GetAllTechsFromStorage()
        {
            var result = databaseHandler.GetQueryResult<DbTechObject>("SELECT * FROM FCT_TechSystem");

            return _mapper.TechObjectFromDb(result);
        }

        public List<TechType> GetAllTechTypesFromStorage()
        {
            var result = databaseHandler.GetQueryResult<DbTechType>("SELECT * FROM DIM_TechType");

            return _mapper.TechTypeFromDb(result);
        }

        public TechObject AddNewTech(TechObject newTech)
        {
            var objectToSave = _mapper.TechObjectToDb(newTech);

            var id = databaseHandler.InsertTech(objectToSave);
            newTech.TechSystemID = (int?)id;

            return newTech;
        }
    }
}
