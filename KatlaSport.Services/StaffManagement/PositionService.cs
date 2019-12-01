using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.StaffCatalogue;
using DbPosition = KatlaSport.DataAccess.StaffCatalogue.Position;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a position service.
    /// </summary>
    public class PositionService : IPositionService
    {
        private readonly IStaffCatalogueContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PositionService"/> class with specified <see cref="IStaffCatalogueContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IStaffCatalogueContext"/>.</param>
        public PositionService(IStaffCatalogueContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<PositionListItem>> GetPositionsAsync()
        {
            var dbPositions = await _context.Positions.OrderBy(p => p.Id).ToArrayAsync();
            var positions = dbPositions.Select(p => Mapper.Map<PositionListItem>(p)).ToList();

            foreach (PositionListItem position in positions)
            {
                position.EmployeeCount = _context.Employees.Where(e => e.PositionId == position.Id).Count();
            }

            return positions;
        }

        /// <inheritdoc/>
        public async Task<Position> GetPositionAsync(int positionId)
        {
            var dbPositions = await _context.Positions.Where(p => p.Id == positionId).ToArrayAsync();
            if (dbPositions.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbPosition, Position>(dbPositions[0]);
        }

        /// <inheritdoc/>
        public async Task<Position> CreatePositionAsync(UpdatePositionRequest createRequest)
        {
            var dbPosition = Mapper.Map<UpdatePositionRequest, DbPosition>(createRequest);
            _context.Positions.Add(dbPosition);

            await _context.SaveChangesAsync();

            return Mapper.Map<Position>(dbPosition);
        }

        /// <inheritdoc/>
        public async Task<Position> UpdatePositionAsync(int positionId, UpdatePositionRequest updateRequest)
        {
            var dbPositions = await _context.Positions.Where(p => p.Id == positionId).ToArrayAsync();
            if (dbPositions.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbPosition = dbPositions[0];

            Mapper.Map(updateRequest, dbPosition);

            await _context.SaveChangesAsync();

            return Mapper.Map<Position>(dbPosition);
        }

        /// <inheritdoc/>
        public async Task DeletePositionAsync(int positionId)
        {
            var dbPositions = await _context.Positions.Where(p => p.Id == positionId).ToArrayAsync();
            if (dbPositions.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbPosition = dbPositions[0];

            _context.Positions.Remove(dbPosition);
            await _context.SaveChangesAsync();
        }
    }
}
