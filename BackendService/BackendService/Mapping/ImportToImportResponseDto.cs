using BackendService.Core.DTOs.Import.Responses;
using BackendService.Model;

namespace BackendService.Mapping
{
    public static class ImportToImportResponseDto
    {
        public static ImportResponseDto Transform(Import import, List<ImportDetailResponseDto> details)
        {
            return new ImportResponseDto
            {
                Id = import.Id,
                Code = import.Code,
                TotalAmount = import.TotalAmount,
                Status = import.Status.ToString(),
                Note = import.Note,
                CreatedTime = import.CreatedTime,
                CreatedBy = import.CreatedBy,
                Details = details
            };
        }
    }

    public static class ImportDetailToImportDetailResponseDto
    {
        public static ImportDetailResponseDto Transform(ImportDetail detail, string productName)
        {
            return new ImportDetailResponseDto
            {
                ProductId = detail.ProductId,
                ProductName = productName,
                Quantity = detail.Quantity,
                ImportPrice = detail.ImportPrice,
                TotalPrice = detail.TotalPrice
            };
        }
    }
}
