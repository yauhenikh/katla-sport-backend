using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a document service.
    /// </summary>
    public interface IDocumentService
    {
        /// <summary>
        /// Gets a list of documents.
        /// </summary>
        /// <returns>A <see cref="Task{List{DocumentListItem}}"/>.</returns>
        Task<List<DocumentListItem>> GetDocumentsAsync();

        /// <summary>
        /// Gets a document with specified identifier.
        /// </summary>
        /// <param name="documentId">A document identifier.</param>
        /// <returns>A <see cref="Task{Document}"/>.</returns>
        Task<Document> GetDocumentAsync(int documentId);

        /// <summary>
        /// Gets a list of documents for specified employee.
        /// </summary>
        /// <param name="employeeId">An employee identifier.</param>
        /// <returns>A <see cref="Task{List{DocumentListItem}}"/>.</returns>
        Task<List<DocumentListItem>> GetDocumentsAsync(int employeeId);

        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateDocumentRequest"/>.</param>
        /// <returns>A <see cref="Task{Document}"/>.</returns>
        Task<Document> CreateDocumentAsync(UpdateDocumentRequest createRequest);

        /// <summary>
        /// Updates an existed document.
        /// </summary>
        /// <param name="documentId">A document identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateDocumentRequest" />.</param>
        /// <returns>A <see cref="Task{Document}"/></returns>
        Task<Document> UpdateDocumentAsync(int documentId, UpdateDocumentRequest updateRequest);

        /// <summary>
        /// Deletes an existed document.
        /// </summary>
        /// <param name="documentId">A document identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteDocumentAsync(int documentId);
    }
}
