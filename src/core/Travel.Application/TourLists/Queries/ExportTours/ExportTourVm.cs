namespace Travel.Application.TourLists.Queries.ExportTours
{
    public class ExportTourVm
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}