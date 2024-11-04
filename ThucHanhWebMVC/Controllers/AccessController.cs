using Microsoft.AspNetCore.Mvc;
using ThucHanhWebMVC.Models;
namespace ThucHanhWebMVC.Controllers
{
    public class AccessController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Login(TUser user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.TUsers.Where(x => x.Username.Equals(user.Username) &&
                x.Password.Equals(user.Password)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.Username.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Access");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Access");
            }
        }
        [HttpPost]
        public IActionResult Register(TUser user)
        {
            // Kiểm tra xem tên người dùng đã tồn tại chưa
            var existingUser = db.TUsers.FirstOrDefault(x => x.Username == user.Username);

            if (existingUser != null)
            {
                TempData["Error"] = "Tên tài khoản đã được sử dụng";
                return View("Register", user);
            }

            // Nếu chưa tồn tại, thêm tài khoản mới
            db.TUsers.Add(new TUser
            {
                Username = user.Username,
                Password = user.Password // Nên mã hóa mật khẩu trước khi lưu
            });
            db.SaveChanges();

            // Chuyển hướng về trang Login sau khi đăng ký thành công
           
            return View("Login");

        }

    }
}
