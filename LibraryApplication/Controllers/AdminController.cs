using LibraryApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers;

public class AdminController : Controller
{
    private UserManager<IdentityUser> userManager;
    
    public AdminController(UserManager<IdentityUser> userManager)
    {
        this.userManager = userManager;
    }
    
    public IActionResult Index()
    {
        return View(userManager.Users);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };
            
            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        
        return View(model);
    }
}