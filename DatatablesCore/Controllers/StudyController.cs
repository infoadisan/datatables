﻿using DatatablesCore.Repository;
using DatatablesCore.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatatablesCore.Controllers
{
    public class StudyController : Controller
    {
        private readonly BronoPlusdbcontext context;

        public StudyController(BronoPlusdbcontext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var patients = context.Patients;
            return View(patients);
        }

        public JsonResult GetStudyList()
        {
            int totalRecord = 0;
            int filterRecord = 0;
            var draw = Request.Form["draw"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
            int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");  
            var data = context.Set<Patient>().AsQueryable();

        }
    }
}