using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using WebAppFooter.Entities;
using WebAppFooter.Models;
using WebAppFooter.Repositories;

namespace WebAppFooter.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFooterRepository footerRepository;
        private readonly IMapper mapper;
        private readonly INotyfService toastService;

        public HomeController(IFooterRepository footerRepository, IMapper mapper, INotyfService notyfService)
        {
            this.footerRepository = footerRepository;
            this.mapper = mapper;
            this.toastService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var results = await footerRepository.GetAll();
            var footerDto = mapper.Map<List<FooterDto>>(results);
            return View(footerDto);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(FooterDto footer)
        {
            var createFooter = mapper.Map<Footer>(footer);

            await footerRepository.Create(createFooter);
            toastService.Success("Footer Added");

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GenerateFileHtml(int id)
        {
            var footer = await footerRepository.GetFooterById(id);

            var footerDto = mapper.Map<FooterDto>(footer);

            var bytes = WebAppFooter.GenerateFileHtml.GenerateFileHtml.GetNewFileHtml(footerDto);

            // set name of file html
            string fileName = $"{footerDto.SiteChange}.html";

            return File(bytes, "text/html", fileName);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            List<string> result = new List<string>();
            if (file != null && file.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    string records = Encoding.UTF8.GetString(stream.ToArray());
                    string[] footers = records.Split('\n');
                    foreach (string footer in footers) 
                    {
                        var model = footer.Split(';');
                        if (model == null || model.Length == 6)
                        {
                            FooterDto footerDto = new FooterDto()
                            {
                                NameSurnameChange = model[0],
                                SiteChange = model[1],
                                EmailChange = model[2],
                                PhoneChange = model[3],
                                DepartmentChange = model[4],
                                LogoChange = model[5]
                            };

                            var bytes = WebAppFooter.GenerateFileHtml.GenerateFileHtml.GetNewFileHtml(footerDto);
                            string fileContent = Encoding.GetEncoding("UTF-8").GetString(bytes);
                            result.Add(fileContent);

                        }
                    }

                    // Tworzenie strumienia pamięci dla archiwum ZIP
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                        {
                            for (int i = 0; i < result.Count; i++)
                            {
                                // Tworzenie pliku HTML w archiwum ZIP
                                var entry = archive.CreateEntry($"page{i + 1}.html");

                                // Zapisywanie zawartości HTML do pliku w archiwum
                                using (var entryStream = entry.Open())
                                using (var streamWriter = new StreamWriter(entryStream, Encoding.UTF8))
                                {
                                    streamWriter.Write(result[i]);
                                }
                            }
                        }

                        // Resetowanie pozycji strumienia do początku
                        memoryStream.Position = 0;

                        // Zwracanie archiwum ZIP jako plik do pobrania
                        return File(memoryStream.ToArray(), "footers/zip", "html_files.zip");
                    }

                }
            }
            else
            {
                toastService.Error("No file uploaded");
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
