using Abp.AspNetCore.Mvc.Authorization;
using AutoMapper;
using LiveLife.Authorization;
using LiveLife.Controllers;
using LiveLife.Events;
using LiveLife.Events.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LiveLife.Web.Controllers
{
    public class EventsController  : LiveLifeControllerBase
    {
        private readonly IEventAppService _eventAppService;
      
        public EventsController(IEventAppService eventAppService, IMapper mapper)
        {
            _eventAppService=eventAppService;
            
        }
        public async Task<IActionResult> Index()
        {
            var model = await _eventAppService.GetAvaialableEvents();
            return View(model);
        }
        public async Task<IActionResult> Join(int id)
        {
            await _eventAppService.JoinToEvent(id );
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Report(int id)
        {
            await _eventAppService.ReportEvent(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UserEvents()
        {
            var model = await _eventAppService.GetUserEventsAsync((int)AbpSession.UserId);
            return View(model);
        }
        public async Task<IActionResult> JoinedEvents()
        {
            var model =await _eventAppService.GetJoinedEvents();
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _eventAppService.DeleteEventAsync(id);
            return RedirectToAction("UserEvents");
        }
        public async Task<IActionResult> DeleteAsAdmin(int id)
        {
            await _eventAppService.DeleteEventAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Leave(int id)
        {
            await _eventAppService.LeaveEvent(id);
            return RedirectToAction("JoinedEvents");
        }
        public async Task <IActionResult> Edit(int id)
        {
            var model = await _eventAppService.GetByIdToEditAsync(id);
            
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateOrUpdateEventDto model)
        {

            await _eventAppService.UpdateEventAsync(model);
            return RedirectToAction("UserEvents");

        }
        public  IActionResult Create()
        {
            var model = new CreateOrUpdateEventDto();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrUpdateEventDto model)
        {

            await _eventAppService.CreateEventAsync(model);
            return RedirectToAction("Index");

        }
        [AbpMvcAuthorize(PermissionNames.Pages_Events_Reports)]
        public async Task<IActionResult> ReportedEvents()
        {
            var model = await _eventAppService.GetReportedEvents();
            return View(model);
        }

    }
}
