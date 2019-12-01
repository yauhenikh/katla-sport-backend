using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a position service.
    /// </summary>
    public interface IPositionService
    {
        /// <summary>
        /// Gets a positions list.
        /// </summary>
        /// <returns>A <see cref="Task{List{PositionListItem}}"/>.</returns>
        Task<List<PositionListItem>> GetPositionsAsync();

        /// <summary>
        /// Gets a position with specified identifier.
        /// </summary>
        /// <param name="positionId">A position identifier.</param>
        /// <returns>A <see cref="Task{Position}"/>.</returns>
        Task<Position> GetPositionAsync(int positionId);

        /// <summary>
        /// Creates a new position.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdatePositionRequest"/>.</param>
        /// <returns>A <see cref="Task{Position}"/>.</returns>
        Task<Position> CreatePositionAsync(UpdatePositionRequest createRequest);

        /// <summary>
        /// Updates an existed position.
        /// </summary>
        /// <param name="positionId">A position identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdatePositionRequest"/>.</param>
        /// <returns>A <see cref="Task{Position}"/>.</returns>
        Task<Position> UpdatePositionAsync(int positionId, UpdatePositionRequest updateRequest);

        /// <summary>
        /// Deletes an existed position.
        /// </summary>
        /// <param name="positionId">A position identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeletePositionAsync(int positionId);
    }
}
