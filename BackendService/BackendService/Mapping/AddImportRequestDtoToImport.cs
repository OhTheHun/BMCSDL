using BackendService.Core.DTOs.Import.Requests;
using BackendService.Model;
using BackendService.Model.Enums;

namespace BackendService.Mapping
{
    public static class AddImportRequestDtoToImport
    {
        public static Import Transform(AddImportRequestDto dto, string code, decimal totalAmount, string actor)
        {
            return new Import
            {
                Code = code,
                TotalAmount = totalAmount,
                Status = ImportEnum.Success,
                Note = dto.Note,
                CreatedBy = actor,
                CreatedTime = DateTime.UtcNow,
                UpdatedBy = actor,
                UpdatedTime = DateTime.UtcNow
            };
        }
    }

    public static class AddImportDetailRequestDtoToImportDetail
    {
        public static ImportDetail Transform(AddImportDetailRequestDto dto, Guid receiptId, string actor)
        {
            return new ImportDetail
            {
                ReceiptId = receiptId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                ImportPrice = dto.ImportPrice,
                TotalPrice = dto.Quantity * dto.ImportPrice,
                CreatedBy = actor,
                CreatedTime = DateTime.UtcNow,
                UpdatedBy = actor,
                UpdatedTime = DateTime.UtcNow
            };
        }
    }
}
