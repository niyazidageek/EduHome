using System;
using System.Collections.Generic;
using EduHome.Models;
using X.PagedList.Mvc.Core;
using X.PagedList;
using X.PagedList.Mvc;

namespace EduHome.ViewModels
{
    public class EventVM
    {
        public IPagedList<Event> Events { get; set; }
    }
}
