using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.StaffManagement
{
    public interface ILocationRepository
    {
        /// <summary>
        /// Gets a locations list.
        /// </summary>
        /// <returns>A <see cref="Task{IEnumerable{LocationListItem}}"/>.</returns>
        Task<IEnumerable<LocationListItem>> GetLocationsAsync();

        /// <summary>
        /// Gets a location with specified identifier.
        /// </summary>
        /// <param name="locationId">A location identifier.</param>
        /// <returns>A <see cref="Task{Location}"/>.</returns>
        Task<Location> GetLocationAsync(int locationId);

        /// <summary>
        /// Creates a new location.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateLocationRequest"/>.</param>
        /// <returns>>A <see cref="Task"/>.</returns>
        Task CreateLocationAsync(UpdateLocationRequest createRequest);

        /// <summary>
        /// Updates an existed location.
        /// </summary>
        /// <param name="locationId">A location identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateLocationRequest"/>.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task UpdateLocationAsync(int locationId, UpdateLocationRequest updateRequest);

        /// <summary>
        /// Deletes an existed location.
        /// </summary>
        /// <param name="locationId">A location identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteLocationAsync(int locationId);

        /// <summary>
        /// Saves changes in the database.
        /// </summary>
        /// <returns>A <see cref="Task"/>.</returns>
        Task SaveAsync();
    }
}
