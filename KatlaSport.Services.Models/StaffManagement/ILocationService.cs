using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a location service.
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Gets a locations list.
        /// </summary>
        /// <returns>A <see cref="Task{List{LocationListItem}}"/>.</returns>
        Task<List<LocationListItem>> GetLocationsAsync();

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
        /// <returns>A <see cref="Task{Location}"/>.</returns>
        Task<Location> CreateLocationAsync(UpdateLocationRequest createRequest);

        /// <summary>
        /// Updates an existed location.
        /// </summary>
        /// <param name="locationId">A location identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateLocationRequest"/>.</param>
        /// <returns>A <see cref="Task{Location}"/>.</returns>
        Task<Location> UpdateLocationAsync(int locationId, UpdateLocationRequest updateRequest);

        /// <summary>
        /// Deletes an existed location.
        /// </summary>
        /// <param name="locationId">A location identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteLocationAsync(int locationId);
    }
}
