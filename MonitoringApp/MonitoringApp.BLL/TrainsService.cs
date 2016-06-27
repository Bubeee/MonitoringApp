using System;
using System.Collections.Generic;
using System.Linq;
using MonitoringApp.DataAccess.Entities;
using MonitoringApp.DataAccess.Repositories;

namespace MonitoringApp.BLL
{
    public class TrainsService : ITrainsService
    {
        private readonly IRepository _repository;

        public TrainsService(IRepository repository)
        {
            _repository = repository;
        }
        
        public List<int> GetObjectIdList()
        {
            return _repository.GetObjectIdList();
        }

        public TrainDataCollectedEntity GetTrainObjectEntity(int systemSerialNo)
        {
            return _repository.GetTrainObjectEntity(systemSerialNo);
        }

        public List<TrainDataCollectedEntity> GetTrainObjectPackages(int systemSerialNo, DateTime from, DateTime to)
        {
            return _repository.GetTrainObjectDataCollectedEntities(systemSerialNo, from, to).ToList();
        }
    }
}