using BackendService.Core.DTOs.Import.Requests;
using BackendService.Core.DTOs.Import.Responses;
using BackendService.Data.Interface;
using BackendService.Mapping;
using BackendService.Model;
using BackendService.Services.Interface;

namespace BackendService.Services
{
    public class ImportService(IImportRepository importRepository, IInventoryRepository inventoryRepository, IOtherService otherService, IProductRepository productRepository) : IImportService
    {
        private readonly IImportRepository _importRepository = importRepository;
        private readonly IInventoryRepository _inventoryRepository = inventoryRepository;
        private readonly IOtherService _otherService = otherService;
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<ImportResponseDto> AddImportAsync(AddImportRequestDto request, string actor, CancellationToken cancellationToken)
        {
            decimal totalAmount = request.Details.Sum(d => d.Quantity * d.ImportPrice);
            string code = _otherService.GenerateRandomCode();

            var import = AddImportRequestDtoToImport.Transform(request, code, totalAmount, actor);
            import.Id = Guid.NewGuid();

            var importDetails = request.Details.Select(d => AddImportDetailRequestDtoToImportDetail.Transform(d, import.Id, actor)).ToList();

            // Cập nhật kho hàng
            foreach (var detail in request.Details)
            {
                var inventory = await _inventoryRepository.GetByProductIdAsync(detail.ProductId, cancellationToken);
                if (inventory != null)
                {
                    inventory.quantity += detail.Quantity;
                    inventory.UpdatedTime = DateTime.UtcNow;
                    inventory.UpdatedBy = actor;
                    await _inventoryRepository.UpdateAsync(inventory, cancellationToken);
                }
                else
                {
                    throw new Exception($"Sản phẩm với ID {detail.ProductId} chưa có dữ liệu trong kho. Vui lòng kiểm tra lại.");
                }
            }

            var createdImport = await _importRepository.CreateImportAsync(import, importDetails, cancellationToken);

            var detailResponses = new List<ImportDetailResponseDto>();
            foreach (var detail in importDetails)
            {
                var product = await _productRepository.GetByIdAsync(detail.ProductId, cancellationToken);
                string productName = product?.ProductName ?? "Unknown Product";
                detailResponses.Add(ImportDetailToImportDetailResponseDto.Transform(detail, productName));
            }

            return ImportToImportResponseDto.Transform(createdImport, detailResponses);
        }

        public async Task<List<ImportResponseDto>> GetImportsAsync(GetImportFilterRequestDto filter, CancellationToken cancellationToken)
        {
            var imports = await _importRepository.GetImportsAsync(filter.FromDate, filter.ToDate, cancellationToken);
            var result = new List<ImportResponseDto>();

            foreach (var import in imports)
            {
                var details = await _importRepository.GetImportDetailsByImportIdAsync(import.Id, cancellationToken);
                var detailResponses = new List<ImportDetailResponseDto>();
                bool matchProductName = string.IsNullOrWhiteSpace(filter.ProductName);

                foreach (var detail in details)
                {
                    var product = await _productRepository.GetByIdAsync(detail.ProductId, cancellationToken);
                    string productName = product?.ProductName ?? "Unknown Product";
                    
                    if (!string.IsNullOrWhiteSpace(filter.ProductName) && productName.Contains(filter.ProductName, StringComparison.OrdinalIgnoreCase))
                    {
                        matchProductName = true;
                    }

                    detailResponses.Add(ImportDetailToImportDetailResponseDto.Transform(detail, productName));
                }

                if (matchProductName)
                {
                    result.Add(ImportToImportResponseDto.Transform(import, detailResponses));
                }
            }

            return result;
        }
    }
}
