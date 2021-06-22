using AutoMapper;
using BusinnesLogicLayer.Interfaces;
using BusinnesLogicLayer.Services;
using ContactManager.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        public IService<BusinnesLogicLayer.DTOModels.PeopleDTO> service;
        public ICSVReader<BusinnesLogicLayer.DTOModels.PeopleDTO> reader;
        public HomeController(IService<BusinnesLogicLayer.DTOModels.PeopleDTO> service, ICSVReader<BusinnesLogicLayer.DTOModels.PeopleDTO> reader)
        {
            this.service = service;
            this.reader = reader;
        }
        public IActionResult Index()
        {
            var firstobj = new MapperConfiguration(map => map.CreateMap<BusinnesLogicLayer.DTOModels.PeopleDTO, PeopleViewModel>()).CreateMapper();
            IEnumerable<PeopleViewModel> list = firstobj.Map<IEnumerable<BusinnesLogicLayer.DTOModels.PeopleDTO>, IEnumerable<PeopleViewModel>>(service.GetListDTO());
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PeopleViewModel user)
        {
            var firstobj = new MapperConfiguration(map => map.CreateMap<PeopleViewModel, BusinnesLogicLayer.DTOModels.PeopleDTO>()).CreateMapper();
            BusinnesLogicLayer.DTOModels.PeopleDTO people = firstobj.Map<PeopleViewModel, BusinnesLogicLayer.DTOModels.PeopleDTO>(user);
            service.CreateDTO(people);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var firstobj = new MapperConfiguration(map => map.CreateMap<BusinnesLogicLayer.DTOModels.PeopleDTO, PeopleViewModel>()).CreateMapper();
                PeopleViewModel people = firstobj.Map<BusinnesLogicLayer.DTOModels.PeopleDTO, PeopleViewModel>(service.FindDTO(id));
                if (people != null)
                {
                    return View(people);
                }
            }
            return NotFound();
        }
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var firstobj = new MapperConfiguration(map => map.CreateMap<BusinnesLogicLayer.DTOModels.PeopleDTO, PeopleViewModel>()).CreateMapper();
                PeopleViewModel people = firstobj.Map<BusinnesLogicLayer.DTOModels.PeopleDTO, PeopleViewModel>(service.FindDTO(id));
                if (people != null)
                {
                    return View(people);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(PeopleViewModel user)
        {
            var firstobj = new MapperConfiguration(map => map.CreateMap<PeopleViewModel, BusinnesLogicLayer.DTOModels.PeopleDTO>()).CreateMapper();
            BusinnesLogicLayer.DTOModels.PeopleDTO people = firstobj.Map<PeopleViewModel, BusinnesLogicLayer.DTOModels.PeopleDTO>(user);
            service.UpdateDTO(people);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var firstobj = new MapperConfiguration(map => map.CreateMap<BusinnesLogicLayer.DTOModels.PeopleDTO, PeopleViewModel>()).CreateMapper();
                PeopleViewModel people = firstobj.Map<BusinnesLogicLayer.DTOModels.PeopleDTO, PeopleViewModel>(service.FindDTO(id));
                if (people != null)
                {
                    return View(people);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(PeopleViewModel user)
        {
            var firstobj = new MapperConfiguration(map => map.CreateMap<PeopleViewModel, BusinnesLogicLayer.DTOModels.PeopleDTO>()).CreateMapper();
            BusinnesLogicLayer.DTOModels.PeopleDTO people = firstobj.Map<PeopleViewModel, BusinnesLogicLayer.DTOModels.PeopleDTO>(user);
            service.DeleteDTO(people.Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Upload(IFormFile upload)
        {
            if (upload != null)
            {
                var firstobj = new MapperConfiguration(map => map.CreateMap<BusinnesLogicLayer.DTOModels.PeopleDTO, PeopleViewModel>()).CreateMapper();
                IEnumerable<PeopleViewModel> list = firstobj.Map<IEnumerable<BusinnesLogicLayer.DTOModels.PeopleDTO>, IEnumerable<PeopleViewModel>>(reader.Parser(upload.OpenReadStream()));
                return View("CSVFile", list);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult CSVFile(List<PeopleViewModel> list)
        {
            if(list != null)
            {
                var firstobj = new MapperConfiguration(map => map.CreateMap<PeopleViewModel, BusinnesLogicLayer.DTOModels.PeopleDTO>()).CreateMapper();
                IEnumerable<BusinnesLogicLayer.DTOModels.PeopleDTO> templist = firstobj.Map<IEnumerable<PeopleViewModel>, IEnumerable<BusinnesLogicLayer.DTOModels.PeopleDTO>>(list);
                service.AddListPeoples(templist);
            }
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
