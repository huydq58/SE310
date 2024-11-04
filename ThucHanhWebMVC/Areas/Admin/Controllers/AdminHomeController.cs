﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThucHanhWebMVC.Models;
using X.PagedList;

namespace ThucHanhWebMVC.Areas.Admin.Controllers
{
    
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class AdminHomeController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("danhmucsanpham")]
        //public IActionResult DanhMucSanPham()
        //{
        //    var lstSanPham = db.TDanhMucSps.ToList();
        //    return View(lstSanPham);
        //}

        // cái này tương tư cái trên + thêm phân trang các table 
        public IActionResult DanhMucSanPham(int? page)
        {
            //List<TDanhMucSp> listSP = db.TDanhMucSps.ToList(); // them vao
            //return View(listSP);

            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            //var listSP = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            var listSP = db.TDanhMucSps.OrderByDescending(sp => sp.MaSp).ToList();
            PagedList<TDanhMucSp> list = new PagedList<TDanhMucSp>(listSP, pageNumber, pageSize);
            return View(list);
            
        }


        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");



            return View();
        }

        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TDanhMucSp sanpham)
        {
            if(ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanpham);
        }
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");



            return View();
        }

        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp sanpham)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Update(sanpham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanpham);
        }

        [Route("XoaSanPham")]
        [HttpGet]


        public IActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
          var chiTietSanPham = db.TChiTietSanPhams.Where(x=>x.MaSp==maSanPham).ToList();
            if(chiTietSanPham.Count>0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này";
                return RedirectToAction("DanhMucSanPham");
            }    
            var anhSanPham = db.TAnhSps.Where(x=>x.MaSp==maSanPham);
            if(anhSanPham.Any()) db.RemoveRange(anhSanPham);
            db.Remove(db.TDanhMucSps.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("DanhMucSanPham");

        }
    }



}
