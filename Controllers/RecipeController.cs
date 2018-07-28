using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CulinaryApplication.Controllers
{
    public class RecipeController : Controller
    {
        RecipeDataAccesLayer objrecipe = new RecipeDataAccesLayer();

        //GET: <controller>/
        public IActionResult Index()
        {
            List<Recipe> lstrecipe = new List<Recipe>();
            lstrecipe = objrecipe.GetAllRecipes().ToList();

            return View(lstrecipe);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                objrecipe.AddRecipe(recipe);
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Recipe recipe = objrecipe.GetRecipeData(id);

            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Recipe recipe)
        {
            if (id != recipe.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objrecipe.UpdateRecipe(recipe);
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Recipe recipe = objrecipe.GetRecipeData(id);

            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Recipe recipe = objrecipe.GetRecipeData(id);

            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objrecipe.DeleteRecipe(id);
            return RedirectToAction("Index");
        }
    }
}
