using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _23Dh114228_MyStore.Models;
using _23Dh114228_MyStore.Models.ViewModel;
using PagedList;
using System.Runtime.Remoting.Messaging;
using System.Web.Security;
namespace _23Dh114228_MyStore.Controllers
{
    public class AccountController : Controller
    {

        private MyStoreEntities db = new MyStoreEntities();

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)

            {
                //kiểm tra xem tên đăng nhập đã tốn tại chưa
                var existingUser = db.Users.SingleOrDefault(u => u.Username == model.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Username", "Tên đăng nhập này đã tồn tại!");
                    return View(model);
                }

                //nếu chưa tổn tại thì tạo bản ghi thông tin tài khoản trong bảng User
                var user = new User

                {
                    Username = model.Username,
                    Password = model.Password, // Lưu ý: Nên mã hóa mật khẩu trước khi lưu
                    UserRole = "Customer"
                };

                db.Users.Add(user);
                //và tạo bản ghi thông tin khách hàng trong bảng Customer
                var customer = new Customer
                {

                    CustomerName = model.CustomerName,
                    CustomerEmail = model.CustomerEmail,

                    CustomerPhone = model.CustomerPhone,
                    CustomerAddress = model.CustomerAddress,
                    Username = model.Username,

                };
                db.Customers.Add(customer);

                // lưu thông tin tài khoản và thông tin khách hàng vào CSDL

                db.SaveChanges();

                return RedirectToAction("Index", "Home");

            }
            return View(model);
        }
        // GET: Account/Login

        public ActionResult Login()

        {
            return View();

        }

        // POST: Account/Login

        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)

            {

                var user = db.Users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password && u.UserRole == "Customer");

                if (user != null)

                {

                    // Lưu trạng thời đăng nhập vào session
                    Session["Username "] = user.Username;
                    Session["UserRole"] = user.UserRole;
                    // lưu thông tin xác thực người dùng vào cookie
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View(model);
        }
        // GET : Account/Logout 
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
} 