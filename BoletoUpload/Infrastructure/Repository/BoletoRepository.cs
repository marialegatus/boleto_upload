using BoletoUpload.Infrastructure.Interface;
using BoletoUpload.Infrastructure.Model;
using BoletoUpload.Application.DTO;
using Npgsql;

namespace BoletoUpload.Infrastructure.Repository
{
    public class BoletoRepository : BaseRepository, IBoletoRepository
    {
        public BoletoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void InsertProcessedUpload(ProcessedBoleto model)
        {
            try
            {
                Connection.Open();

                using var cmd = new NpgsqlCommand();

                
                string sql = @"INSERT INTO processed_upload(operation_date, customer_code, operation_type, 
                                    stock_exchange_id, asset_code, broker, quantity, unit_price, 
                                    operation_financial_value, operation_discount_value, status, error_message) 
                                VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8}, {9}, '{10}', '{11}')";
                sql = String.Format(sql, model.Date, model.CustomerCode, model.OperationType, model.StockExchangeId, 
                    model.AssetCode, model.Broker, model.Quantity, model.UnitPrice, model.OperationFinancialValue, 
                    model.OperationDiscountValue, model.Status, model.ErrorMessage);

                cmd.CommandText = sql;
                cmd.Connection = Connection;

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Connection.Close();
            }
        }

        public void InsertUpload(BoletoDTO model)
        {
            try
            {
                Connection.Open();

                using var cmd = new NpgsqlCommand();
                string sql = @"INSERT INTO upload(operation_date, customer_code, operation_type, 
                                    stock_exchange_id, asset_code, broker, quantity, unit_price) 
                                VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7})";
                sql = String.Format(sql, model.Date, model.CustomerCode, model.Type, model.StockExchangeId, model.AssetCode, model.Broker, model.Quantity, model.UnitPrice);

                cmd.CommandText = sql;
                cmd.Connection = Connection;

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Connection.Close();
            }
        }
    }
}
