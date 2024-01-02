using ExportDataToOfficeApp;
using Excel = Microsoft.Office.Interop.Excel;

var carsInStock = new List<Car>
{
    new() {Color="Зелёный", Make="VW", PetName="Мэри"},
    new() {Color="Красный", Make="Saab", PetName="Мэл"},
    new() {Color="Чёрный", Make="Ford", PetName="Хэнк"},
    new() {Color="Жёлтый", Make="BMW", PetName="Дэви"}
};
ExportToExcel(carsInStock);
ExportToExcelManual(carsInStock);

static void ExportToExcel(List<Car> carsInStock)
{
    // Загрузить Excel и затем создать новую пустую рабочую книгу.
    var excelApp = new Excel.Application
    {
        // Сделать пользовательский интерфейс Excel видимым на рабочем столе.
        Visible = true
    };
    excelApp.Workbooks.Add();

    // В этом примере используется единственный рабочий лист.
    var workSheet = (Excel._Worksheet)excelApp.ActiveSheet;

    // Установить заголовки столбцов в ячейках.
    workSheet.Cells[1, "A"] = "Изготовитель";
    workSheet.Cells[1, "B"] = "Цвет";
    workSheet.Cells[1, "C"] = "Дружественное имя";

    // Отобразить все данные в List<Car> на ячейки электронной таблицы.
    int row = 1;
    foreach (Car c in carsInStock)
    {
        row++;
        workSheet.Cells[row, "A"] = c.Make;
        workSheet.Cells[row, "B"] = c.Color;
        workSheet.Cells[row, "C"] = c.PetName;
    }

    // Придать симпатичный вид табличным данным.
    workSheet.Range["A1"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);

    // Сохранить файл, завершить работу Excel и отобразить сообщение пользователю.
    workSheet.SaveAs($@"{Environment.CurrentDirectory}\Inventory.xlsx");
    excelApp.Quit();
    Console.WriteLine("Файл Inventory.xslx сохранён в папке приложения");
}

static void ExportToExcelManual(List<Car> carsInStock)
{
    var excelApp = new Excel.Application();

    // Потребуется пометить пропущенные параметры!
    excelApp.Workbooks.Add(Type.Missing);

    // Потребуется привести объект Object к _Worksheet!
    var workSheet = (Excel._Worksheet)excelApp.ActiveSheet;

    // Потребуется привести каждый объект Object к Range и затем обратиться к низкоуровневому свойству Value2!
    ((Excel.Range)excelApp.Cells[1, "A"]).Value2 = "Make";
    ((Excel.Range)excelApp.Cells[1, "B"]).Value2 = "Color";
    ((Excel.Range)excelApp.Cells[1, "C"]).Value2 = "Pet Name";
    int row = 1;
    foreach (Car c in carsInStock)
    {
        row++;

        // Потребуется привести каждый объект Object к Range и затем обратиться к низкоуровневому свойству Value2!
        ((Excel.Range)workSheet.Cells[row, "A"]).Value2 = c.Make;
        ((Excel.Range)workSheet.Cells[row, "B"]).Value2 = c.Color;
        ((Excel.Range)workSheet.Cells[row, "C"]).Value2 = c.PetName;
    }

    // Потребуется вызвать метод get_Range с указанием всех пропущенных аргументов!
    excelApp.get_Range("A1", Type.Missing)
        .AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

    // Потребуется указать все пропущенные необязательные аргументы!
    workSheet.SaveAs($@"{Environment.CurrentDirectory}\InventoryManual.xlsx",
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    excelApp.Quit();
    Console.WriteLine("Файл InventoryManual.xslx сохранён в папке приложения");
}