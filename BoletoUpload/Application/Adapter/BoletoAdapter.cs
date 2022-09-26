using TradingUpload.Domain.Aggregate.Builder;
using TradingUpload.Application.ViewModel;
using TradingUpload.Domain.Aggregate;
using TradingUpload.Application.DTO;
using TradingUpload.Domain.Entity;
using TradingUpload.Domain.Enum;
using System.Globalization;

namespace TradingUpload.Application.Adapter
{
    public static class BoletoAdapter
    {
        public static List<string> ToListString(this string line, string separator)
        {
            if (String.IsNullOrEmpty(line))
                throw new ArgumentNullException(nameof(line));

            var result = line.Split(separator).ToList();
            result.RemoveAt(0);
            result.RemoveAt(result.Count - 1);

            return result;
        }
        
        public static BoletoDTO ToDTO(this List<string> args)
        {
            try
            {
                string format = "yyyyMMdd";
                CultureInfo provider = CultureInfo.InvariantCulture;
                var referenceDate = DateTime.ParseExact(args[0], format, provider);

                var result = new BoletoDTO()
                {
                    Date = referenceDate,
                    CustomerCode = args[1],
                    Type = args[2],
                    StockExchangeId = args[3],
                    AssetCode = args[4],
                    Broker = args[5],
                    Quantity = String.IsNullOrEmpty(args[6]) ? 0 : Convert.ToInt32(args[6]),
                    UnitPrice = String.IsNullOrEmpty(args[7]) ? 0 : Convert.ToDecimal(args[7])
                };

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static List<BoletoDTO> ToListDTO(this IFormFile file, string fileStart, string fileEnd, string fileSeparator)
        {
            List<BoletoDTO> boletosDTO = new List<BoletoDTO>();

            if (file.Length > 0)
            {
                var lines = GetFileLines(file);

                var readyToReadFile = false;
                foreach (string line in lines.Result)
                {
                    if (!readyToReadFile && line.Equals(fileStart))
                    {
                        readyToReadFile = true;
                    }
                    else
                    if (readyToReadFile)
                    {
                        if (line.Equals(fileEnd))
                        {
                            break;
                        }
                        var result = line.ToListString(fileSeparator);
                        var trade = result.ToDTO();
                        boletosDTO.Add(trade);
                    }
                }
            }

            return boletosDTO;
        }

        public static Boleto ToEntity(this BoletoDTO model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            if (!Enum.TryParse(model.Type, true, out OperationType type))
            {
                throw new ArgumentException($"Invalid argument {nameof(type)}.");
            }

            var builder = new BoletoBuilder();
            builder.SetDate(model.Date).
                SetAssetCode(model.AssetCode).
                SetOperationType(type).
                SetIds(model.StockExchangeId).
                SetBroker(model.Broker).
                SetValues(model.Quantity, model.UnitPrice);

            return builder.Build();
        }

        public static List<Portfolio> ToListAggregate(this List<BoletoDTO> boletos)
        {
            if (boletos is null)
            {
                return new List<Portfolio>(0);
            }

            var result = new List<Portfolio>();
            Portfolio portfolio = new Portfolio();

            foreach (var boleto in boletos)
            {
                if (result.FirstOrDefault(x => x.CustomerCode.Equals(boleto.CustomerCode)) is null)
                {
                    portfolio = new Portfolio().SetCustomerCode(boleto.CustomerCode);
                    portfolio.AddBoleto(boleto.ToEntity());
                    result.Add(portfolio);
                }
                else
                {
                    result.Find(x => x.CustomerCode.Equals(boleto.CustomerCode)).AddBoleto(boleto.ToEntity());
                }
            }
            return result;
        }

        public static IEnumerable<BoletoView> ToEnumerableView(this IEnumerable<Boleto> boletos)
        {
            if (boletos is null)
            {
                return new List<BoletoView>(0);
            }

            var result = boletos.Select(ToView);
            return result;
        }

        public static IEnumerable<PortfolioView> ToEnumerableView(this IEnumerable<Portfolio> trades)
        {
            if (trades is null)
            {
                return new List<PortfolioView>(0);
            }

            var result = trades.Select(ToView);
            return result;
        }

        public static PortfolioView ToView(Portfolio model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var result = new PortfolioView()
            {
                CustomerCode = model.CustomerCode,
                Boletos = model.Boletos.ToEnumerableView().ToList()
            };

            return result;
        }

        public static BoletoView ToView(Boleto model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var result = new BoletoView()
            {
                Date = model.Date.ToString("yyy/dd/MM"),
                OperationType = model.OperationType.ToString(),
                StockExchangeId = model.StockExchangeId,
                AssetCode = model.AssetCode,
                Broker = model.Broker,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                OperationFinancialValue = model.OperationFinancialValue,
                OperationDiscountValue = model.OperationDiscountValue is null ? 0 : model.OperationDiscountValue,
                BoletoStatus = model.Status.ToString(),
                ErrorMessage = String.IsNullOrEmpty(model.ErrorMessage) ? String.Empty : model.ErrorMessage
            };

            return result;
        }

        private static async Task<string[]> GetFileLines(IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            using (var stream = File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
            return File.ReadAllLines(filePath);
        }
    }
}
