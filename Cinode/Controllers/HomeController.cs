using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Cinode.Models;
using System.Net;

namespace Cinode.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        /// <summary>
        /// Return all skills data as a list.
        /// </summary>
        /// <returns>Json skill list.</returns>
        public JsonResult GetSkills()
        {
            return Json(Skill.SkillList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Add new skill intp skill list.
        /// </summary>
        /// <param name="newSkill">skill object came from client-side.</param>
        /// <returns>Return skill information. If it returns null, it means the skill is not suitable to add.</returns>
        public JsonResult AddSkill(Skill newSkill)
        {
            Skill skillObj = Skill.SkillList.Where(x => x.Name == newSkill.Name).FirstOrDefault();
            if (skillObj != null)
            {
                return null;
            }
            else
            {
                Skill.SkillList.Add(newSkill);
                return Json(Skill.SkillList, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Remove a skill.
        /// </summary>
        /// <param name="skillId"></param>
        public void RemoveSkill(int skillId)
        {
            Skill skill = Skill.SkillList.Where(x => x.Id == skillId).FirstOrDefault();
            if (skill != null)
            {
                Skill.SkillList.Remove(skill);
            }
        }

        /// <summary>
        /// Change rate of a skill already added.
        /// </summary>
        /// <param name="skill"></param>
        public void ChangeRate(Skill skill)
        {
            Skill skillObj = Skill.SkillList.Where(x => x.Id == skill.Id).FirstOrDefault();
            if (skillObj != null)
            {
                skillObj.Rate = skill.Rate;
            }
        }
    }
}
