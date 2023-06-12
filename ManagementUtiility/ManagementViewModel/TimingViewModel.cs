using ManagemeantModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ManagementViewModel
{
    public class TimingViewModel
    {
        public int Id { get; set; }
        public AppUser Adminid { get; set; }
        public DateTime Date { get; set; }
        public int MorningshiftStartTime { get; set; }
        public int MorningshiftEndTime { get; set; }

        public int AfterNoonShfitStartTime { get; set; }
        public int AfterNoonShfitEndTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
        List<SelectListItem> morningshiftStartTime =new List<SelectListItem>();
        List<SelectListItem> morningshiftEndTime = new List<SelectListItem>();
        List<SelectListItem> afterNoonShfitStartTime = new List<SelectListItem>();
        List<SelectListItem> afterNoonShfitEndTime = new List<SelectListItem>();

        

        public TimingViewModel()
        {
            
        }

        public TimingViewModel(Timing model)
        {
            Id = model.Id;
            Date = model.Date;
            MorningshiftStartTime= model.MorningshiftStartTime;
            MorningshiftEndTime = model.MorningshiftEndTime;
            AfterNoonShfitStartTime= model.AfterNoonShfitStartTime;
            AfterNoonShfitEndTime=model.AfterNoonShfitEndTime;
            Duration = model.Duration;
            Status = model.Status;
            Adminid = model.admin;

        }

        public Timing ConvertViewModel(TimingViewModel model)
        {
            return new Timing
            {
                Id = model.Id,
                Date = model.Date,
                MorningshiftStartTime = model.MorningshiftStartTime,
                MorningshiftEndTime = model.MorningshiftEndTime,
                AfterNoonShfitStartTime = model.AfterNoonShfitStartTime,
                AfterNoonShfitEndTime = model.AfterNoonShfitEndTime,
                Duration = model.Duration,
                Status = model.Status,
                admin = model.Adminid

        };

        }
}
