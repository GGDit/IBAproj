using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.BLL.Validation
{
  public static  class Validator
    {
        public static bool IsTimeOfRecordCorrect(Record rec, IDoctorRepository docRepo, out string errorMessage)
        {
            errorMessage = "";
            if (rec.TimeOfRecord < DateTime.Now)
            {
                errorMessage = "Нельзя попасть в прошлое";
                return false;
            }
            Doctor doc = docRepo.GetById(rec.DoctorId);

            DateTime dateStart = new DateTime(rec.TimeOfRecord.Year, rec.TimeOfRecord.Month, rec.TimeOfRecord.Day, doc.StartTimeOfReceipt, 0, 0);

            DateTime dateEnd = new DateTime(rec.TimeOfRecord.Year, rec.TimeOfRecord.Month, rec.TimeOfRecord.Day, doc.EndTimeOfReceipt, 0, 0);

            if (rec.TimeOfRecord < dateStart || rec.TimeOfRecord > dateEnd)
            {
                errorMessage = "Врач в это время не принимает";
                return false;
            }
            return true;
        }

        public static bool isTimeOfReceiptCorrect(Doctor doc, out string errorMessage)
        {
            errorMessage = "";
            if (doc.StartTimeOfReceipt < 8 || doc.StartTimeOfReceipt >= 20)
            {
                errorMessage = "Время начала приема вне диапазона времени работы поликлиники";
                return false;
            }
            if (doc.EndTimeOfReceipt < 8 || doc.EndTimeOfReceipt >= 20)
            {
                errorMessage = "Время окончания приема вне диапазона времени работы поликлиники";
                return false;
            }
            if (doc.StartTimeOfReceipt >= doc.EndTimeOfReceipt)
            {
                errorMessage = "Время начала приема больше времени окончания приема";
                return false;
            }

            return true;
        }
    }
}
