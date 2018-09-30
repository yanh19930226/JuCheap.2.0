using AutoMapper;
using JuCheap.Core.Extentions;
using JuCheap.Entity.Mall;
using JuCheap.Service.Abstracts.Mall.IServices;
using JuCheap.Service.Dto;
using JuCheap.Web.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace JuCheap.Web.Areas.Adm.Controllers
{
    public class StoreIndustriesController : AdmBaseController
    {
        public IStoreIndustriesService storeIndustriesService { set; get; }

        // GET: Adm/StoreIndustries
        public ActionResult Index(int moudleId, int menuId, int btnId)
        {
            GetButtons(menuId);
            return View();
        }
        public JsonResult GetList(int moudleId, int menuId, int btnId)
        {
            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };
            Expression<Func<StoreIndustriesEntity, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.SearchKey.IsBlank())
                exp = exp.And(item => item.Title.Contains(queryBase.SearchKey));

            var dto = storeIndustriesService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(string moudleId, string menuId, string btnId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(int moudleId, int menuId, int btnId, StoreIndustriesDto dto)
        {
            Random rd = new Random();
            dto.Displayorder = rd.Next(1, 100); //1到100之间的数，可任意更改
            var entity = dto.MapTo<StoreIndustriesEntity>();
            storeIndustriesService.Add(entity);
            return RedirectToAction("Index", RouteData.Values);
        }
        public ActionResult Edit(int moudleId, int menuId, int btnId, int id)
        {
            var model = storeIndustriesService.GetOne(item => item.Id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int moudleId, int menuId, int btnId, StoreIndustriesDto dto)
        {
            var entity = Mapper.Map<StoreIndustriesDto, StoreIndustriesEntity>(dto);
            storeIndustriesService.Update(entity);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public JsonResult Delete(int moudleId, int menuId, int btnId, List<int> ids)
        {
            var res = new Result<string>();


            if (ids != null && ids.Any())
                res.flag = storeIndustriesService.Delete(item => ids.Contains(item.Id));

            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}