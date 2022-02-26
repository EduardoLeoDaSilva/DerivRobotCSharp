using System.Reflection;
using OfficeOpenXml;

namespace DerivSmartRobot.Services;

public class ExcelService
{
    public string SalvarArquivo<T>(List<T> data)
    {
        string filePath = "C:\\ExcelDemo.xlsx";

        var stream = new MemoryStream();
        using (var package = new ExcelPackage(stream))
        {
            var workSheet = package.Workbook.Worksheets.Add("Usuarios Cadastrados");
            workSheet.Cells.LoadFromCollection(data, true);
            // package.Save();
            

            //or if you use asp.net, get the relative path
            filePath =  Path.GetDirectoryName(Assembly.GetExecutingAssembly(). CodeBase);
            filePath = Path.Combine(filePath, "Pasta\\ExcelDemo.xlsx");
            //Write the file to the disk
            FileInfo fi = new FileInfo(filePath);
            package.SaveAs(fi);
        }

        return filePath;
    }
}