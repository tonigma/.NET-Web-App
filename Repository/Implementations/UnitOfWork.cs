using DataBase.Context;
using DataBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private TravelDbContext6 context = new TravelDbContext6();
        private GenericRepository<Country> countryRepository;
        private GenericRepository<Region> regionRepository;
        private GenericRepository<Place> placeRepository;

        public GenericRepository<Country> CountryRepository
        {
            get
            {

                if (this.countryRepository == null)
                {
                    this.countryRepository = new GenericRepository<Country>(context);
                }
                return countryRepository;
            }
        }

        public GenericRepository<Region> RegionRepository
        {
            get
            {

                if (this.regionRepository == null)
                {
                    this.regionRepository = new GenericRepository<Region>(context);
                }
                return regionRepository;
            }
        }

        public GenericRepository<Place> PlaceRepository
        {
            get
            {

                if (this.placeRepository == null)
                {
                    this.placeRepository = new GenericRepository<Place>(context);
                }
                return placeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
