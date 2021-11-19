using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace BlazorReporting.Server
{
    public class CustomReportStorageWebExtension : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
    {
        public override bool CanSetData(string url)
        {
            // Check if the URL is available in the report storage.
            var item = ReportFactory.Reports.FirstOrDefault(x => x.Name == url);
            return item != null;
        }


        public override byte[] GetData(string url)
        {
            // Get the report data from the storage.
            var item = ReportFactory.Reports.FirstOrDefault(x => x.Name == url);
            using (MemoryStream ms = new MemoryStream())
            {
                item.Report.SaveLayoutToXml(ms);
                return ms.ToArray();
            }
        }


        public override Dictionary<string, string> GetUrls()
        {
            // Get URLs and display names for all reports available in the storage.
            var dictionary = new Dictionary<string, string>();
            foreach (var item in ReportFactory.Reports)
            {
                dictionary.Add(item.Name, item.DisplayName);
            }
            return dictionary;
        }


        public override bool IsValidUrl(string url)
        {
            // Check if the specified URL is valid for the current report storage.
            var item = ReportFactory.Reports.FirstOrDefault(x => x.Name == url);
            return item != null;
        }


        public override void SetData(XtraReport report, string url)
        {
            // Write a report to the storage under the specified URL.
            var item = ReportFactory.Reports.FirstOrDefault(x => x.Name == url);
            if (item != null)
            {
                item.Report = report;
            }
        }


        public override string SetNewData(XtraReport report, string defaultUrl)
        {
            // Write a report to the storage under a new URL.
            var item = ReportFactory.Reports.FirstOrDefault(x => x.DisplayName == defaultUrl);
            if (item != null)
            {
                item.Report = report;
                return item.Name;
            }
            else
            {
                var url = ReportFactory.Reports.Count.ToString();
                ReportFactory.Reports.Add(new ReportInfo { DisplayName = defaultUrl, Name = url, Report = report });
                return url;
            }
        }
    }
}
