using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace CB_Base.Classes
{
    static class Licencias
    {

        public class HardDrive
        {
            public string Model { get; set; }
            public string InterfaceType { get; set; }
            public string Caption { get; set; }
            public string SerialNo { get; set; }
        }

        static private List<HardDrive> EnlistarHDDs()
        {
            List<HardDrive> hdCollection = new List<HardDrive>();
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDrive hd = new HardDrive();
                hd.Model = wmi_HD["Model"].ToString();
                hd.InterfaceType = wmi_HD["InterfaceType"].ToString();
                hd.Caption = wmi_HD["Caption"].ToString();
                hd.SerialNo = wmi_HD.GetPropertyValue("SerialNumber").ToString();//get the serailNumber of diskdrive

                hdCollection.Add(hd);
            }
            return hdCollection;
        }

    }
}
