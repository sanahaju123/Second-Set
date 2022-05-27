using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InterviewTracker.Entities
{
    /// <summary>
    /// This Enum define key value pair for User Status. its bind on User Status DropDownList
    /// </summary>
    public enum Status
    {
        Locked,
        Bench,
        [Display(Name = "In Training")]
        InTraining,
        Released
    }
}
