using BackendService.Data.DataContext;
using BackendService.Data.Interface;
using BackendService.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Data
{
    public class InvoiceRepository(AppDbContext context) : IInvoiceRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<Invoice>> GetAllInvoicesAsync(CancellationToken cancellationToken)
        {
            return await _context.Invoices
                .Where(i => i.DeleteFlag == false)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Invoice>> GetInvoicesByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken)
        {
            return await _context.Invoices
                .Where(i => i.CustomerId == customerId && i.DeleteFlag == false)
                .ToListAsync(cancellationToken);
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(Guid invoiceId, CancellationToken cancellationToken)
        {
            return await _context.Invoices
                .FirstOrDefaultAsync(i => i.Id == invoiceId && i.DeleteFlag == false, cancellationToken);
        }

        public async Task<List<InvoiceItem>> GetInvoiceItemsByInvoiceIdAsync(Guid invoiceId, CancellationToken cancellationToken)
        {
            return await _context.InvoiceItems
                .Where(ii => ii.InvoiceId == invoiceId && ii.DeleteFlag == false)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Product>> GetProductsByIdsAsync(List<Guid> productIds, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(p => productIds.Contains(p.Id) && p.DeleteFlag == false)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateInvoiceAsync(Invoice invoice, CancellationToken cancellationToken)
        {
            if (invoice.Status == Model.Enums.InvoiceEnum.Canceled)
            {
                string sqlCancel = @"EXEC SP_Cancel_Order @InvoiceId = {0}, @UpdatedBy = {1}";
                await _context.Database.ExecuteSqlRawAsync(sqlCancel, invoice.Id, invoice.UpdatedBy ?? "system");
            }
            else
            {
                string sql = @"
                    EXEC SP_Update_Invoice_Status 
                        @InvoiceId = {0}, 
                        @NewStatus = {1}, 
                        @UpdatedBy = {2}";

                await _context.Database.ExecuteSqlRawAsync(sql, 
                    invoice.Id, 
                    (int)invoice.Status, 
                    invoice.UpdatedBy ?? "system");
            }
        }

        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice, CancellationToken cancellationToken)
        {
            string sql = @"
                EXEC SP_Create_Invoice 
                    @Id = {0},
                    @CustomerId = {1}, 
                    @Code = {2}, 
                    @PaymentMethod = {3}, 
                    @TotalAmount = {4}, 
                    @CreatedBy = {5}";

            await _context.Database.ExecuteSqlRawAsync(sql, 
                invoice.Id,
                invoice.CustomerId, 
                invoice.Code, 
                invoice.PaymentMethod, 
                invoice.TotalAmount, 
                invoice.CreatedBy ?? "system");

            return invoice;
        }

        public async Task<InvoiceItem[]> CreateListInvoiceItemAsync(InvoiceItem[] invoiceItems, CancellationToken cancellationToken)
        {
            foreach (var item in invoiceItems)
            {
                string sql = @"
                    EXEC SP_Add_Invoice_Item 
                        @InvoiceId = {0}, 
                        @ProductId = {1}, 
                        @Quantity = {2}, 
                        @Price = {3}, 
                        @CreatedBy = {4}";

                await _context.Database.ExecuteSqlRawAsync(sql, 
                    item.InvoiceId, 
                    item.ProductId, 
                    item.Quantity, 
                    item.Total, 
                    item.CreatedBy ?? "system");
            }
            return invoiceItems;
        }

        public async Task<List<Invoice>> GetOrdersForApprovalAsync(CancellationToken cancellationToken)
        {
            return await _context.Invoices
                .Where(i => i.DeleteFlag == false && i.Status != Model.Enums.InvoiceEnum.Canceled && i.Status != Model.Enums.InvoiceEnum.Completed)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Invoice>> GetProcessedOrdersByActorAsync(string userId, CancellationToken cancellationToken)
        {
            return await _context.Invoices
                .Where(i => i.DeleteFlag == false && 
                           i.UpdatedBy == userId && 
                           (i.Status == Model.Enums.InvoiceEnum.Completed || i.Status == Model.Enums.InvoiceEnum.Canceled))
                .ToListAsync(cancellationToken);
        }
        public async Task<List<Invoice>> GetInvoicesByStatusAsync(Model.Enums.InvoiceEnum status, CancellationToken cancellationToken)
        {
            return await _context.Invoices
                .Where(i => i.DeleteFlag == false && i.Status == status)
                .ToListAsync(cancellationToken);
        }
    }
}
