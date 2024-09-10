using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using RFID_Device_Management.Models;// Ensure this matches the namespace where RfidContext is defined
using RFID_Device_Management.DAL;
using System.Security.Cryptography;

public class HomeController : Controller
{
   
    private RFID_Device_Management.DAL.RfidContext db = new RFID_Device_Management.DAL.RfidContext();

    // GET: Login
    public ActionResult Login()
    {
        return View(); 
    }
    // POST: Login
    [HttpPost]
    public ActionResult Login(User model)
    {
        if (ModelState.IsValid)
        { 
            var user = db.Users.FirstOrDefault(u => u.Username == model.Username);

            if (user != null)
            {
                string inputPasswordHash = model.PasswordHash;
                string storedPasswordHash = user.PasswordHash;
                // Compare the hashed password in-memory
                bool isPasswordValid = VerifyPassword(inputPasswordHash, storedPasswordHash);

                if (isPasswordValid)
                {
                    // Set the authentication cookie
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Index"); // Redirect to the dashboard after successful login
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid username or password";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password";
            }
        }

        return View();
    }
    private bool VerifyPassword(string inputPasswordHash, string storedPasswordHash)
    {
      
        return inputPasswordHash == storedPasswordHash;
    }


    [Authorize]
    public ActionResult Index()
    {
        return View(); 
    }

    public ActionResult Logout()
    {
        FormsAuthentication.SignOut();
        return RedirectToAction("Login");
    }
}

