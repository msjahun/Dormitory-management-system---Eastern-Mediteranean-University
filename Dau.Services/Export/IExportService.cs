namespace Dau.Services.Export
{
    public interface IExportService
    { 
        void ExportToPdf();
        string ExportToExcel();
        string ExportDormitoryBlocksToExcel(int id);
        string ExportRoomsToExcel(int id);
        string ExportUsersToExcel(int id);
        string ExportBookingsToExcel(int id);
        string ExportDormitoryToExcel(int id);
    }
}