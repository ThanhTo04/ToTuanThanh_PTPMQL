using ClosedXML.Excel;
using MvcMovie.Models;

namespace MvcMovie.Services
{
    public class ExcelService
    {
        public List<Customer> ReadCustomers(string filePath)
        {
            var list = new List<Customer>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var ws = workbook.Worksheet(1);

                foreach (var row in ws.RangeUsed().RowsUsed().Skip(1))
                {
                    var customer = new Customer
                    {
                        Name = row.Cell(2).GetValue<string>(),
                        Email = row.Cell(3).GetValue<string>()
                    };

                    list.Add(customer);
                }
            }

            return list;
        }
    }
}