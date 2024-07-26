using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

            WebAppFooter.GenerateFileHtml.GenerateFileHtml.GetNewFileHtml(footerDto);

            return RedirectToAction(nameof(Index));
        }


    }
}
