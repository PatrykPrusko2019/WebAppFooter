
using WebAppFooter.Models;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace WebAppFooter.GenerateFileHtml
{
    public class GenerateFileHtml
    {

        public static byte[] GetNewFileHtml(FooterDto footerDto)
        {
            
            string footerString = File.ReadAllText("wwwroot/Template/template.html");

            footerString = footerString.Replace("NameSurnameChange", footerDto.NameSurnameChange);
            footerString = footerString.Replace("SiteChange", footerDto.SiteChange);
            footerString = footerString.Replace("EmailChange", footerDto.EmailChange);
            footerString = footerString.Replace("PhoneChange", footerDto.PhoneChange);
            footerString = footerString.Replace("DepartmentChange", footerDto.DepartmentChange);
            footerString = footerString.Replace("LogoChange", footerDto.LogoChange);

            
            byte[] bytes = Encoding.UTF8.GetBytes(footerString);

            return bytes;

            //// Ścieżka do zapisania pliku HTML na pulpicie
            //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string filePath = Path.Combine(desktopPath, $"{footerDto.SiteChange}.html");

            //// Tworzenie pliku HTML na pulpicie z podaną zawartością
            //try
            //{
            //    File.WriteAllText(filePath, footerString);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}

        }
    }
}
