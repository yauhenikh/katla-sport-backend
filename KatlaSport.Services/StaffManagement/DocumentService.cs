using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.StaffCatalogue;
using DbDocument = KatlaSport.DataAccess.StaffCatalogue.Document;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a document service.
    /// </summary>
    public class DocumentService : IDocumentService
    {
        private readonly IStaffCatalogueContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentService"/> class with specified <see cref="IStaffCatalogueContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IStaffCatalogueContext"/>.</param>
        public DocumentService(IStaffCatalogueContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<DocumentListItem>> GetDocumentsAsync()
        {
            var dbDocuments = await _context.Documents.OrderBy(d => d.Id).ToArrayAsync();
            var documents = dbDocuments.Select(d => Mapper.Map<DocumentListItem>(d)).ToList();

            return documents;
        }

        /// <inheritdoc/>
        public async Task<Document> GetDocumentAsync(int documentId)
        {
            var dbDocuments = await _context.Documents.Where(d => d.Id == documentId).ToArrayAsync();
            if (dbDocuments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbDocument, Document>(dbDocuments[0]);
        }

        /// <inheritdoc/>
        public async Task<List<DocumentListItem>> GetDocumentsAsync(int employeeId)
        {
            var dbDocuments = await _context.Documents.Where(d => d.EmployeeId == employeeId).OrderBy(d => d.Id).ToArrayAsync();
            var documents = dbDocuments.Select(d => Mapper.Map<DocumentListItem>(d)).ToList();

            return documents;
        }

        /// <inheritdoc/>
        public async Task<Document> CreateDocumentAsync(UpdateDocumentRequest createRequest)
        {
            var dbDocument = Mapper.Map<UpdateDocumentRequest, DbDocument>(createRequest);
            _context.Documents.Add(dbDocument);

            await _context.SaveChangesAsync();

            return Mapper.Map<Document>(dbDocument);
        }

        /// <inheritdoc/>
        public async Task<Document> UpdateDocumentAsync(int departmentId, UpdateDocumentRequest updateRequest)
        {
            var dbDocuments = await _context.Documents.Where(d => d.Id == departmentId).ToArrayAsync();
            if (dbDocuments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbDocument = dbDocuments[0];

            Mapper.Map(updateRequest, dbDocument);

            await _context.SaveChangesAsync();

            return Mapper.Map<Document>(dbDocument);
        }

        /// <inheritdoc/>
        public async Task DeleteDocumentAsync(int documentId)
        {
            var dbDocuments = await _context.Documents.Where(d => d.Id == documentId).ToArrayAsync();
            if (dbDocuments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbDocument = dbDocuments[0];

            _context.Documents.Remove(dbDocument);
            await _context.SaveChangesAsync();
        }
    }
}
