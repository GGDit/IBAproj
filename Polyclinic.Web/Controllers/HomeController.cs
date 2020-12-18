using Polyclinic.BLL.EntitiesDTO;
using Polyclinic.BLL.Interfaces;
using Polyclinic.Web.Filters;
using Polyclinic.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Polyclinic.Web.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        IDoctorService doctorService;
        IRecordService recordService;
        IPatientService patientService;
        public HomeController(IDoctorService doctorService, IRecordService recordService, IPatientService patientService)
        {
            this.doctorService = doctorService;
            this.recordService = recordService;
            this.patientService = patientService;
        }

        public ActionResult Index()
        {
            for (int i = 0; i < 5; i++)
            {
                Session["res" + i] = true;
            }
            IEnumerable<DoctorDTO> doctors = doctorService.GetAll();
            List<DoctorViewModel> doctorsView = new List<DoctorViewModel>();

            foreach (var item in doctors)
            {
                doctorsView.Add(
                    new DoctorViewModel
                    {
                        Id = item.Id,
                        Lastname = item.Lastname,
                        EndTimeOfReceipt = item.EndTimeOfReceipt,
                        StartTimeOfReceipt = item.StartTimeOfReceipt,
                        Room = item.Room,
                        Specialty = item.Specialty
                    });
            }
            //получаем список специальностей

            List<String> specialyties = doctorsView.Select(d => d.Specialty).Distinct().ToList();
            //формируем модель для представления Index
            IndexViewModel model = new IndexViewModel
            {

                Speciality = specialyties,
                Doctors = doctorsView.Where(d => d.Specialty == specialyties[0]).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult DocSearch(string selectSpec)
        {
            IEnumerable<DoctorDTO> doctors = doctorService.GetAll().Where(d => d.Specialty == selectSpec).ToList();
            //получаем List<DoctorViewModel> из doctors
            List<DoctorViewModel> allDocs = new List<DoctorViewModel>();

            foreach (var item in doctors)
            {
                allDocs.Add(new DoctorViewModel
                {
                    Id = item.Id,
                    Lastname = item.Lastname,
                    Specialty = item.Specialty,
                    StartTimeOfReceipt = item.StartTimeOfReceipt,
                    EndTimeOfReceipt = item.EndTimeOfReceipt,
                    Room = item.Room
                });
            }

            return PartialView(allDocs);

        }
        [HttpGet]
        public ActionResult RecordsList(int? id)
        {
            ListRecordViewModel list = new ListRecordViewModel();
            //лист записей на следующую неделю
            IList<DateTime> records = new List<DateTime>();
            //узнаем дату ближайшего понедельника
            DateTime beginDate = DateTime.Now + TimeSpan.FromDays(7 - (DateTime.Now.DayOfWeek - DayOfWeek.Monday));
            //Заполняем список
            for (int i = 0; i < 5; i++)
            {
                records.Add(beginDate.AddDays(i));
            }
            list.Dates = records;
            list.Doctor = doctorService.GetById((int)id);
            return PartialView(list);
        }

        public ActionResult ChangeLanguage(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            string culture = "";
            if (lang == "Еnglish")
                culture = "en";
            else
            {
                culture = "ru";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie == null)      
            {
                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
               
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            cookie.Value = culture;
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult MakeRecord(int id, DateTime date, string res)
        {
            if (Session[res] == null)
                Session[res] = false;
            else
                Session[res] = !(bool)Session[res];//запоминаем состояние формы для записи
            Session["div"] = res;
            DoctorDTO doctor = doctorService.GetById(id);
            RecordViewModel record = new RecordViewModel();

            record.DoctorId = doctor.Id;
            record.Date = date;
            //разбиваем время приема на отрезочки для пациентов
            Dictionary<string, int> times = new Dictionary<string, int>();
            IEnumerable<RecordDTO> records = recordService.GetAll();

            int curTime = doctor.StartTimeOfReceipt;
            int curTimeSpan = 0;
            int timeForPatient = 20;

            while (curTime < doctor.EndTimeOfReceipt)
            {
                string timeS = curTime + ":" + curTimeSpan.ToString("d2");
                DateTime curDate = Convert.ToDateTime(date.ToShortDateString() + " " + timeS);
                if (!records.Any(r => (r.DoctorId == id && r.TimeOfRecord == curDate)))
                {
                    times.Add(timeS, 0);
                }
                else
                {
                    times.Add(timeS, 1);
                }
                curTimeSpan += timeForPatient;
                if (curTimeSpan == 60)
                {
                    curTimeSpan = 0;
                    curTime += 1;
                }
            }
            record.Time = times;
            return PartialView(record);
        }
        [HttpPost]
        public ActionResult MakeRecord(RecordViewModel record)
        {
            RecordDTO recordForSave = new RecordDTO();
            PatientDTO patient = patientService.GetAll().FirstOrDefault(p => (p.Surname == record.PatientLastname));
            if (patient != null)
            {
                recordForSave.PatientId = patient.Id;
                recordForSave.DoctorId = record.DoctorId;
                recordForSave.TimeOfRecord = Convert.ToDateTime(record.Date.ToShortDateString() + " " + record.TimeOfRecord);
                recordService.Create(recordForSave);
            }
            return RedirectToAction("Index");
        }






        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}