using QLTS.BLL;
using QLTS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLTS_Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["GIANGVIEN"] != null)
                    {
                        bizGIANGVIEN GIANGVIEN = (bizGIANGVIEN)Session["GIANGVIEN"];
                        HoTen.InnerText = GIANGVIEN.TENGV == null || GIANGVIEN.TENGV == "" ? "Chào Giảng viên" : "Chào " + GIANGVIEN.TENGV;
                        LinkButtonLogout.Visible = true;
                    }
                    else
                    {
                        LinkButtonLogout.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<script>alert('Lỗi: {0}');</script>", ex.Message));
            }
        }

        protected void ButtonDangKySuDungPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["GiangVien"] == null)
                {
                    TableDangNhap.Visible = true;
                    TableDangKySuDungPhong.Visible = PanelTaiSanTheoPhong.Visible = PanelTaiSanTheoLoaiTaiSan.Visible = false;
                    LinkButtonLogout.Visible = false;
                }
                else
                {
                    TableDangKySuDungPhong.Visible = true;
                    TableDangNhap.Visible = PanelTaiSanTheoPhong.Visible = PanelTaiSanTheoLoaiTaiSan.Visible = false;
                    LinkButtonLogout.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<script>alert('Lỗi: {0}');</script>", ex.Message));
            }
        }

        protected void ButtonXemTaiSanTheoLoaiTaiSan_Click(object sender, EventArgs e)
        {
            try
            {
                PanelTaiSanTheoLoaiTaiSan.Visible = true;
                TableDangKySuDungPhong.Visible = PanelTaiSanTheoPhong.Visible = TableDangNhap.Visible = false;

                List<bizLOAITAISAN> LISTLOAITAISAN = dalLOAITAISAN.getall();
                ListBoxLoaiTaiSan.DataSource = LISTLOAITAISAN;
                ListBoxLoaiTaiSan.DataValueField = "ID";
                ListBoxLoaiTaiSan.DataTextField = "TENLOAI";
                ListBoxLoaiTaiSan.DataBind();

                ListBoxLoaiTaiSan.SelectedIndex = 0;
                ListBoxLoaiTaiSan.Focus();

                if (LISTLOAITAISAN != null && LISTLOAITAISAN.Count() > 0)
                {
                    tenloaitaisan.InnerHtml = LISTLOAITAISAN.FirstOrDefault().TENLOAI == null || LISTLOAITAISAN.FirstOrDefault().TENLOAI == "" ? "" : LISTLOAITAISAN.FirstOrDefault().TENLOAI;
                    List<bizTAISAN> LISTTAISAN = dalTAISAN.getall().Where(c => c.LOAITAISAN.ID == LISTLOAITAISAN.FirstOrDefault().ID).ToList();
                    if (LISTTAISAN == null || LISTTAISAN.Count() < 1)
                    {
                        tenloaitaisan.InnerHtml += " <font color='red'>[Không có tài sản]</font>";
                    }
                    else
                    {
                        tenloaitaisan.InnerHtml += string.Format(" <font color='red'>[Có {0} tài sản]</font>", LISTTAISAN.Count());
                    }
                    GridViewTaiSanTheoLoai.DataSource = LISTTAISAN;
                    GridViewTaiSanTheoLoai.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<script>alert('Lỗi: {0}');</script>", ex.Message));
            }
        }

        protected void ButtonXemTaiSanTheoPhong_Click(object sender, EventArgs e)
        {
            try
            {
                PanelTaiSanTheoPhong.Visible = true;
                TableDangKySuDungPhong.Visible = PanelTaiSanTheoLoaiTaiSan.Visible = TableDangNhap.Visible = false;

                List<bizPHONG> LISTPHONG = dalPHONG.getall();
                var LISTPHONGCUSTOM = LISTPHONG.Select(item => new
                {
                    ID = item.ID,
                    TENPHONG = item.DIADIEM.TANG == null ? string.Format("{0} [{1}]", item.TENPHONG, item.DIADIEM.COSO.TENCOSO) : string.Format("{0} [{1} - {2} - {3}]", item.TENPHONG, item.DIADIEM.COSO == null ? "" : item.DIADIEM.COSO.TENCOSO, item.DIADIEM.KHU == null ? "" : item.DIADIEM.KHU.TEN, item.DIADIEM.TANG == null ? "" : item.DIADIEM.TANG.TENTANG)
                });
                ListBoxPhong.DataSource = LISTPHONGCUSTOM;
                ListBoxPhong.DataValueField = "ID";
                ListBoxPhong.DataTextField = "TENPHONG";
                ListBoxPhong.DataBind();

                ListBoxPhong.SelectedIndex = 0;
                ListBoxPhong.Focus();

                if (LISTPHONGCUSTOM != null && LISTPHONGCUSTOM.Count() > 0)
                {
                    tenphong.InnerHtml = LISTPHONG.FirstOrDefault().TENPHONG == null || LISTPHONG.FirstOrDefault().TENPHONG == "" ? "" : LISTPHONG.FirstOrDefault().TENPHONG;
                    List<bizCTTAISAN> LISTCTTAISAN = dalCTTAISAN.TaiSan(LISTPHONGCUSTOM.FirstOrDefault().ID).ToList();
                    if (LISTCTTAISAN == null || LISTCTTAISAN.Count() < 1)
                    {
                        tenphong.InnerHtml += " <font color='red'>[Không có tài sản]</font>";
                    }
                    else
                    {
                        tenphong.InnerHtml += string.Format(" <font color='red'>[Có {0} tài sản]</font>", LISTPHONGCUSTOM.Count());
                    }
                    var LISTTAISAN = LISTCTTAISAN.Select(item => new
                    {
                        ID = item.ID,
                        SUBID = item.TAISAN.SUBID,
                        TEN = item.TAISAN.TENTAISAN,
                        SOLUONG = item.SOLUONG,
                        TINHTRANG = item.TINHTRANG.VALUE,
                        NGAYNHAP = item.NGAY,
                        MOTA = item.MOTA
                    }).ToList();
                    GridViewTaiSanTheoPhong.DataSource = LISTTAISAN;
                    GridViewTaiSanTheoPhong.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<script>alert('Lỗi: {0}');</script>", ex.Message));
            }
        }

        protected void ButtonDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxTaiKhoan.Text.Trim().Equals(""))
                {
                    LabelThongBaoDangNhap.Text = "Tài khoản không được trống";
                    TextBoxTaiKhoan.Focus();
                    return;
                }
                if (TextBoxMatKhau.Text.Trim().Equals(""))
                {
                    LabelThongBaoDangNhap.Text = "Mật khẩu không được trống";
                    TextBoxMatKhau.Focus();
                    return;
                }
                bizGIANGVIEN GIANGVIEN = dalGIANGVIEN.getbyusername(TextBoxTaiKhoan.Text.Trim());
                if (Object.Equals(GIANGVIEN, null))
                {
                    LabelThongBaoDangNhap.Text = "Tài khoản không tồn tại";
                    TextBoxTaiKhoan.Focus();
                    return;
                }
                if (!Object.Equals(GIANGVIEN.PASSWORD, TextBoxMatKhau.Text.Trim()))
                {
                    LabelThongBaoDangNhap.Text = "Mật khẩu không chính xác";
                    TextBoxMatKhau.Focus();
                    return;
                }
                TableDangNhap.Visible = false;
                Session["GIANGVIEN"] = GIANGVIEN;
                HoTen.InnerText = GIANGVIEN.TENGV == null || GIANGVIEN.TENGV == "" ? "Chào Giảng viên" : "Chào " + GIANGVIEN.TENGV;
                TableDangKySuDungPhong.Visible = true;
                LinkButtonLogout.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<script>alert('Lỗi: {0}');</script>", ex.Message));
            }
        }

        protected void ButtonMuonPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxKhoaPhongMuon.Text.Trim().Equals(""))
                {
                    LabelThongBaoDangKySuDungPhong.Text = "Khoa/Phòng mượn không được trống";
                    TextBoxKhoaPhongMuon.Focus();
                    return;
                }
                if (TextBoxNgayMuon.Text.Trim().Equals(""))
                {
                    LabelThongBaoDangKySuDungPhong.Text = "Ngày mượn không được trống";
                    TextBoxNgayMuon.Focus();
                    return;
                }
                if (TextBoxTuGio.Text.Trim().Equals(""))
                {
                    LabelThongBaoDangKySuDungPhong.Text = "Giờ bắt đầu không được trống";
                    TextBoxTuGio.Focus();
                    return;
                }
                if (TextBoxDenGio.Text.Trim().Equals(""))
                {
                    LabelThongBaoDangKySuDungPhong.Text = "Giờ kết thúc không được trống";
                    TextBoxDenGio.Focus();
                    return;
                }
                if (TextBoxSoLuongSinhVien.Text.Trim().Equals(""))
                {
                    LabelThongBaoDangKySuDungPhong.Text = "Số lượng sinh viên không được trống";
                    TextBoxSoLuongSinhVien.Focus();
                    return;
                }
                if (TextBoxLyDoMuon.Text.Trim().Equals(""))
                {
                    LabelThongBaoDangKySuDungPhong.Text = "Lý do mượn không được trống";
                    TextBoxLyDoMuon.Focus();
                    return;
                }

                bizPHIEUMUONPHONG PHIEUMUONPHONG = new bizPHIEUMUONPHONG();
                PHIEUMUONPHONG.KHOA = TextBoxKhoaPhongMuon.Text.Trim();
                try
                {
                    if (Convert.ToDateTime(TextBoxNgayMuon.Text.Trim()) < DateTime.Now.Date)
                    {
                        LabelThongBaoDangKySuDungPhong.Text = "Ngày mượn phải lớn hơn hoặc trùng với ngày hiện tại";
                        TextBoxNgayMuon.Focus();
                        return;
                    }
                }
                catch
                {
                    LabelThongBaoDangKySuDungPhong.Text = "Ngày mượn không đúng định dạng";
                    TextBoxNgayMuon.Focus();
                    return;
                }
                try
                {
                    DateTime ThoiGianMuon = Convert.ToDateTime(TextBoxNgayMuon.Text.Trim() + " " + TextBoxTuGio.Text.Trim());
                    PHIEUMUONPHONG.NGAYMUON = ThoiGianMuon;
                }
                catch
                {
                    LabelThongBaoDangKySuDungPhong.Text = "Giờ bắt đầu không đúng định dạng";
                    TextBoxTuGio.Focus();
                    return;
                }
                try
                {
                    DateTime ThoiGianTra = Convert.ToDateTime(TextBoxNgayMuon.Text.Trim() + " " + TextBoxDenGio.Text.Trim());
                    PHIEUMUONPHONG.NGAYTRA = ThoiGianTra;
                }
                catch
                {
                    LabelThongBaoDangKySuDungPhong.Text = "Giờ kết thúc không đúng định dạng";
                    TextBoxDenGio.Focus();
                    return;
                }
                try
                {
                    PHIEUMUONPHONG.SOLUONGSV = Int32.Parse(TextBoxSoLuongSinhVien.Text.Trim());
                }
                catch
                {
                    LabelThongBaoDangKySuDungPhong.Text = "Số lượng sinh viên không đúng định dạng";
                    TextBoxSoLuongSinhVien.Focus();
                    return;
                }
                PHIEUMUONPHONG.LYDOMUON = TextBoxLyDoMuon.Text.Trim();
                try
                {
                    bizGIANGVIEN GIANGVIEN = (bizGIANGVIEN)Session["GIANGVIEN"];
                    if (Object.Equals(GIANGVIEN, null))
                    {
                        LabelThongBaoDangKySuDungPhong.Text = "Thời gian đăng nhập đã hết hạn. Vui lòng đăng nhập lại.";
                        return;
                    }
                    PHIEUMUONPHONG.NGUOIMUON_ID = GIANGVIEN.ID;
                    PHIEUMUONPHONG.GIANGVIENMUON = true;
                }
                catch
                {
                    LabelThongBaoDangKySuDungPhong.Text = "Thời gian đăng nhập đã hết hạn. Vui lòng đăng nhập lại.";
                    return;
                }
                if (dalPHIEUMUONPHONG.them(PHIEUMUONPHONG) == true)
                {
                    LabelThongBaoDangKySuDungPhong.Text = "Mượn phòng thành công. <br />Chúng tôi sẽ thông báo đến bạn qua email trong thời gian sớm nhất.";
                    LabelThongBaoDangKySuDungPhong.ForeColor = System.Drawing.Color.Blue;
                }
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<script>alert('Lỗi: {0}');</script>", ex.Message));
            }
        }

        protected void ListBoxLoaiTaiSan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int IDLOAITAISAN = Int32.Parse(ListBoxLoaiTaiSan.SelectedValue.ToString());
                bizLOAITAISAN LOAITAISAN = dalLOAITAISAN.getbyid(IDLOAITAISAN);
                if (LOAITAISAN != null)
                {
                    tenloaitaisan.InnerHtml = LOAITAISAN.TENLOAI == null || LOAITAISAN.TENLOAI == "" ? "" : LOAITAISAN.TENLOAI;
                    List<bizTAISAN> LISTTAISAN = dalTAISAN.getall().Where(c => c.LOAITAISAN.ID == LOAITAISAN.ID).ToList();
                    if (LISTTAISAN == null || LISTTAISAN.Count() < 1)
                    {
                        tenloaitaisan.InnerHtml += " <font color='red'>[Không có tài sản]</font>";
                    }
                    else
                    {
                        tenloaitaisan.InnerHtml += string.Format(" <font color='red'>[Có {0} tài sản]</font>", LISTTAISAN.Count());
                    }
                    GridViewTaiSanTheoLoai.DataSource = LISTTAISAN;
                    GridViewTaiSanTheoLoai.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<script>alert('Lỗi: {0}');</script>", ex.Message));
            }
        }

        protected void ListBoxPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int IDPHONG = Int32.Parse(ListBoxPhong.SelectedValue.ToString());
                bizPHONG PHONG = dalPHONG.getbyid(IDPHONG);
                if (PHONG != null)
                {
                    tenphong.InnerHtml = PHONG.TENPHONG == null || PHONG.TENPHONG == "" ? "" : PHONG.TENPHONG;
                    List<bizCTTAISAN> LISTCTTAISAN = dalCTTAISAN.TaiSan(PHONG.ID).ToList();
                    if (LISTCTTAISAN == null || LISTCTTAISAN.Count() < 1)
                    {
                        tenphong.InnerHtml += " <font color='red'>[Không có tài sản]</font>";
                    }
                    else
                    {
                        tenphong.InnerHtml += string.Format(" <font color='red'>[Có {0} tài sản]</font>", LISTCTTAISAN.Count());
                    }
                    var LISTTAISAN = LISTCTTAISAN.Select(item => new
                    {
                        ID = item.ID,
                        SUBID = item.TAISAN.SUBID,
                        TEN = item.TAISAN.TENTAISAN,
                        SOLUONG = item.SOLUONG,
                        TINHTRANG = item.TINHTRANG.VALUE,
                        NGAYNHAP = item.NGAY,
                        MOTA = item.MOTA
                    }).ToList();
                    GridViewTaiSanTheoPhong.DataSource = LISTTAISAN;
                    GridViewTaiSanTheoPhong.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<script>alert('Lỗi: {0}');</script>", ex.Message));
            }
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<script>alert('Lỗi: {0}');</script>", ex.Message));
            }
        }
    }
}