using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
namespace WebBanHang.Controllers
{
    public class LuuTinController : Controller
    {
        public DBWebThue db = new DBWebThue();
        // GET: LuuTin
        public ActionResult Index()
        {
            Cart cart = getCart();

            return View(cart);
        }
        public Cart getCart()
        {
            Cart cart = (Cart)Session["CART"];
            if (cart == null)
            {
                cart = new Cart();
                Session["CART"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {

            Cart cart = getCart();

            TINTUC p = db.TINTUC.Find(id);
            cart.AddItem(p);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateCart(int[] ID_TinTuc)
        {

            Cart cart = getCart();

            for (int i = 0; i < ID_TinTuc.Length; i++)
            {
          
                TINTUC p = db.TINTUC.Find(ID_TinTuc[i]);
                cart.UpdateItem(p);
            }
            return RedirectToAction("Index");
        }
    }
}