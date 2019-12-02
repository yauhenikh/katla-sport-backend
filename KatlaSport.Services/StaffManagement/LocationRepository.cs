using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.StaffCatalogue;
using DbLocation = KatlaSport.DataAccess.StaffCatalogue.Location;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a location repository.
    /// </summary>
    public class LocationRepository : ILocationRepository
    {
        private readonly IStaffCatalogueContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationRepository"/> class with specified <see cref="IStaffCatalogueContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IStaffCatalogueContext"/>.</param>
        public LocationRepository(IStaffCatalogueContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LocationListItem>> GetLocationsAsync()
        {
            var dbLocations = await _context.Locations.OrderBy(l => l.Id).ToArrayAsync();
            var locations = dbLocations.Select(l => Mapper.Map<LocationListItem>(l)).ToList();

            foreach (LocationListItem location in locations)
            {
                location.DepartmentCount = _context.Departments.Where(d => d.LocationId == location.Id).Count();
            }

            return locations;
        }

        /// <inheritdoc/>
        public async Task<Location> GetLocationAsync(int locationId)
        {
            var dbLocations = await _context.Locations.Where(l => l.Id == locationId).ToArrayAsync();
            if (dbLocations.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbLocation, Location>(dbLocations[0]);
        }

        /// <inheritdoc/>
        public async Task CreateLocationAsync(UpdateLocationRequest createRequest)
        {
            var dbLocation = Mapper.Map<UpdateLocationRequest, DbLocation>(createRequest);
            _context.Locations.Add(dbLocation);
        }

        /// <inheritdoc/>
        public async Task UpdateLocationAsync(int locationId, UpdateLocationRequest updateRequest)
        {
            var dbLocations = await _context.Locations.Where(l => l.Id == locationId).ToArrayAsync();
            if (dbLocations.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbLocation = dbLocations[0];

            Mapper.Map(updateRequest, dbLocation);
        }

        /// <inheritdoc/>
        public async Task DeleteLocationAsync(int locationId)
        {
            var dbLocations = await _context.Locations.Where(l => l.Id == locationId).ToArrayAsync();
            if (dbLocations.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbLocation = dbLocations[0];

            _context.Locations.Remove(dbLocation);
        }

        /// <inheritdoc/>
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
